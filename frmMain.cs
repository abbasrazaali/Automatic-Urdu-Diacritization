using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Media;
using Stemmer_;

namespace Urdu_Diacritization
{
    public partial class frmMain : Form
    {
        public const int HTEMPTY = -1, HTNIL = -2;
        public String projectName = "خود کار اُردو اعراب لگانا";
        public String initDir = "D:\\MS\\Thesis\\Thesis-II\\Implementation\\Urdu_Diacritization\\data";

        public Hashtable prefixDiac = new Hashtable();
        public Hashtable prefixPron = new Hashtable();
        public Hashtable suffixDiac = new Hashtable();
        public Hashtable suffixPron = new Hashtable();
        public Hashtable ccLex = new Hashtable();
        public Hashtable pronLex = new Hashtable();
        public Hashtable pronPOSLex = new Hashtable();
        public Hashtable pronCor = new Hashtable();
        public Hashtable tokLex = new Hashtable();
        public Hashtable POSwordTag = new Hashtable();
        public Hashtable POStagPtag = new Hashtable();
        public Hashtable langModel = new Hashtable();
        public Hashtable diacModel = new Hashtable();
        public Lexicon lexicon;
        public Stemmer stem = new Stemmer();

        static int MAX_WORDS = 100;
        static int MAX_TAGS = 8;
        int w = 0, t = 0, i = 0, j = 0, maxIndx = 0, wordLength = 0, diacLength;
        Double max = 0.0, curr = 0.0, calc = 0.0, UKNProb = 0.0;
        bool UKN = true, isPOStagged = false;
        long tok_count = 0, pos_count = 0, cor_count = 0, lexi_count = 0, aff_count = 0, root_count = 0, pref_count = 0, suff_count = 0, diacr_count = 0;
        public Lexicon[] toks;
        public Lexicon[] test_toks;
        public static Int32 toks_length;
        public static String word = null, predictedDiac = null, diacrit = null;
        public static String[] words = new String[MAX_WORDS];
        public static String[] tag = new String[MAX_TAGS];
        public static String[] predictedTag = new String[MAX_WORDS];
        public static String diac = "", diacritics = "", taggedText = "";
        public static int[,] backPtr = new int[MAX_WORDS, MAX_TAGS];
        public static int[] sequence = new int[MAX_WORDS];
        public static Double[,] score = new Double[MAX_WORDS, MAX_TAGS];

        public frmMain()
        {
            InitializeComponent();

            Text = projectName;
            opnMain.InitialDirectory = initDir;
            savMain.InitialDirectory = initDir;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                wordWrapToolStripMenuItem.Checked = true;

                loadAffixes("data\\Prefix.txt", "data\\Suffix.txt");
                loadWordList("data\\WordList.txt");
                loadCloseClassLexicon("data\\CCLexicon.txt");
                loadPronLexicon("data\\PronLexicon.txt");
                loadPronCorpus("data\\PronCorpus.txt");
                loadPOSProb("data\\POS\\POS.txt", "data\\POS\\POSModel.txt", "data\\POS\\languageModel.txt");
                loadDiacProb("data\\Diac\\diacritics.txt", "data\\Diac\\diacritizationModel.txt", "data\\Diac\\languageModel.txt");

                if (Stemmer_.Stemmer.Load_Processing_Words())
                    setMessage("Affixes are loaded successfully.", false);
                else
                    setMessage("Affixes are failed load.", false);

                statusBar.Text = "Automatic Urdu Diacritization";
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.Text = "";
                Text = projectName;
                toks = null;
                toks_length = 0;

                EnableDisable(0);

                statusBar.Text = "Automatic Urdu Diacritization";
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (opnMain.ShowDialog() == DialogResult.OK)
                {
                    StreamReader openWriter = File.OpenText(opnMain.FileName);
                    txtInput.Text = openWriter.ReadToEnd();
                    openWriter.Close();
                    Text = projectName + " - " + opnMain.FileName;
                    toks = null;
                    toks_length = 0;
                    isPOStagged = false;

                    EnableDisable(0);

                    statusBar.Text = opnMain.FileName + " is opened.";
                }
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult buttonClicked = savMain.ShowDialog();
                if (buttonClicked.Equals(DialogResult.OK))
                {
                    StreamWriter saveWriter = new StreamWriter(savMain.OpenFile());
                    saveWriter.Write(txtInput.Text);
                    saveWriter.Close();
                    Text = projectName + " - " + savMain.FileName;

                    EnableDisable(0);

                    statusBar.Text = "File saved successfully.";
                }
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.Undo();
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.Cut();
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.Copy();
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.Paste();
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.SelectAll();
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.WordWrap == true)
                {
                    txtInput.WordWrap = false;
                    wordWrapToolStripMenuItem.Checked = false;
                }
                else
                {
                    txtInput.WordWrap = true;
                    wordWrapToolStripMenuItem.Checked = true;
                }
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fntMain.ShowDialog();
                txtInput.Font = fntMain.Font;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void normalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisable(1);
                
                txtInput.Text = normalize(txtInput.Text.ToString());
                
                setMessage("Text is normalized.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void undiacritizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisable(2);
                
                txtInput.Text = unDiacritize(txtInput.Text.ToString());
                
                setMessage("Diacritics are removed from the text.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void tokenizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 i = 0, j = 0;

            EnableDisable(3);

            try
            {
                tok_count = 0;

                toks_length = txtInput.Text.Split(' ', '\n').Length;
                toks = new Lexicon[toks_length + 1000];
                while (i < toks_length + 1000)
                    toks[i++] = new Lexicon();

                i = 0;
                while (i < txtInput.Text.Length)
                {
                    while (i < txtInput.Text.Length && txtInput.Text[i] != '-' && txtInput.Text[i] != '۔' && txtInput.Text[i] != '؟')
                    {
                        if (txtInput.Text[i] == ' ' || txtInput.Text[i] == '،' || txtInput.Text[i] == '؛' && txtInput.Text[i] != '\n')
                        {
                            while (txtInput.Text[i] == ' ')
                                i++;
                            i--;    
                            j++;
                        }
                        else
                        {
                            toks[j].word += txtInput.Text[i];
                            toks[j].diac += "L";
                        }
                        i++;
                    }

                    if (i < txtInput.Text.Length)
                    {
                        toks[++j].word = txtInput.Text[i++].ToString();
                        toks[j].diac = "L";

                        j++;
                    }

                    while (i < txtInput.Text.Length && txtInput.Text[i] == ' ') 
                        i++;
                }
                toks_length = j;

                tok_count = toks_length;

                setMessage(tok_count.ToString() + " tokens are found from the lexicon.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void searchFromCorpusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableDisable(5);

            try
            {
                i = 0;
                cor_count = 0;
                if (toks == null || toks.Length == 0 || toks_length == 0)
                {
                    setMessage("Untokenize text cannot passed for corpus based search.", false);
                    return;
                }

                txtInput.Text = null;

                if (toks[i].pron == null)
                {
                    if (toks[i].pos == null)
                        txtInput.Text = txtInput.Text + toks[i].word + " ";
                    else
                        txtInput.Text = txtInput.Text + toks[i].word + "<" + toks[i].pos + ">" + " ";
                }
                else
                {
                    if (toks[i].pos == null)
                        txtInput.Text = txtInput.Text + toks[i].pron + " ";
                    else
                        txtInput.Text = txtInput.Text + toks[i].pron + "<" + toks[i].pos + ">" + " ";
                }

                for (i++; i < toks_length; i++)
                {
                    if (toks[i].done != true && pronCor[unDiacritize(toks[i - 1].word) + unDiacritize(toks[i].word)] != null)
                    {
                        toks[i].pron = pronCor[toks[i - 1].word + unDiacritize(toks[i].word)].ToString();
                        toks[i].text_color = Color.SteelBlue;
                        toks[i].done = true;

                        cor_count++;
                    }

                    txtInput.SelectionColor = toks[i].text_color;
                    if (toks[i].pron == null)
                    {
                        if (toks[i].pos == null)
                            txtInput.AppendText(toks[i].word + " ");
                        else
                            txtInput.AppendText(toks[i].word + "<" + toks[i].pos + ">" + " ");
                    }
                    else
                    {
                        if (toks[i].pos == null)
                            txtInput.AppendText(toks[i].pron + " ");
                        else
                            txtInput.AppendText(toks[i].pron + "<" + toks[i].pos + ">" + " ");
                    }
                }

                setMessage(cor_count.ToString() + " tokens are found from the corpus.", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, projectName);
            }
        }

        private void searchFromLexiconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long i;
            EnableDisable(6);

            try
            {
                lexi_count = 0;

                if (toks == null || toks.Length == 0 || toks_length == 0)
                {
                    setMessage("Untokenize text cannot passed for lexicon based search.", false);
                    return;
                }
                if (isPOStagged == false)
                {
                    setMessage("Text cannot passed for lexicon based search without Part-of-Speech tagging.", false);
                    return;
                }

                txtInput.Text = null;
                for (i = 0; i < toks_length; i++)
                {
                    if (toks[i].done == false && ccLex[toks[i].word + toks[i].pos] != null)
                    {
                        toks[i].pron = ccLex[toks[i].word + toks[i].pos].ToString();
                        toks[i].text_color = Color.ForestGreen;
                        toks[i].done = true;
                        lexi_count++;
                    }
                    else if (toks[i].done == false && pronPOSLex[toks[i].word + toks[i].pos] != null)
                    {
                        toks[i].pron = pronPOSLex[toks[i].word + toks[i].pos].ToString();
                        toks[i].text_color = Color.ForestGreen;
                        toks[i].done = true;
                        lexi_count++;
                    }

                    txtInput.SelectionColor = toks[i].text_color;
                    if (toks[i].pron != null)
                        txtInput.AppendText(toks[i].pron + "<" + toks[i].pos + ">" + " ");
                    else
                       txtInput.AppendText(toks[i].word + "<" + toks[i].pos + ">" + " ");
                }
                setMessage(lexi_count.ToString() + " tokens are found from the lexicon.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void morphemesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*int i = 0, j = 0, k = 0;
            bool preff, sufff;
            String pref, suff, pref_root, root_suff;
            */
            int prefLen = 0, suffLen = 0, stemLen = 0;
            string pref = null, suff = null, stem = null;
            pref_count = root_count = suff_count = 0;

            EnableDisable(7);

            try
            {
                if (toks == null || toks.Length == 0 || toks_length == 0)
                {
                    setMessage("Untokenize text cannot passed for lexicon based search.", false);
                    return;
                }

                txtInput.Text = null;

                for (i = 0; i < toks_length; i++)
                {
                    if (toks[i].done == false)
                    {
                        Stemmer.Extract_Stem(toks[i].word, ref pref, ref suff, ref stem);

                        if (stem != null && pronLex[stem] != null)
                        {
                            stemLen = stem.Length;
                            stem = pronLex[stem].ToString();
                        }
                        else if (stem != null)
                            stemLen = stem.Length;
                        else
                        {
                            stem = null;
                            stemLen = 0;
                        }

                        if (pref != null && prefixPron[pref] != null)
                        {
                            prefLen = pref.Length;
                            pref = prefixPron[pref].ToString();
                        }
                        else if (pref != null)
                            prefLen = pref.Length;
                        else
                        {
                            pref = null;
                            prefLen = 0;
                        }

                        if (suff != null && suffixPron[suff] != null)
                        {
                            suffLen = suff.Length;
                            suff = suffixPron[suff].ToString();
                        }
                        else if (suff != null)
                            suffLen = suff.Length;
                        else
                        {
                            suff = null;
                            suffLen = 0;
                        }

                        if (stemLen != 0 && (prefLen != 0 || suffLen != 0))
                        {
                            toks[i].text_color = Color.DarkOrange;
                            root_count++;
                        }
                        if (prefLen != 0)
                        {
                             toks[i].pron = pref + stem;
                            if(stemLen != 0)
                                toks[i].pref_diac = pref + stem;
                            if(suffLen != 0)
                                toks[i].pref_diac += suff;
                            if ((prefLen + stemLen) == toks[i].word.Length)
                                 toks[i].done = true;
                             pref_count++;
                        }
                        if (suffLen != 0)
                        {
                            toks[i].pron = stem + suff;
                            if(stemLen != 0)
                                toks[i].suff_diac = stem + suff;
                            if (prefLen != 0)
                                toks[i].suff_diac = pref + toks[i].suff_diac;
                            if ((stemLen + suffLen) == toks[i].word.Length)
                                toks[i].done = true;
                            suff_count++;
                        }
                        aff_count++;
                    }
                
                    // display
                    txtInput.SelectionColor = toks[i].text_color;
                    if (toks[i].pron == null)
                    {
                        if (toks[i].pos == null)
                            txtInput.AppendText(toks[i].word + " ");
                        else
                            txtInput.AppendText(toks[i].word + "<" + toks[i].pos + ">" + " ");
                    }
                    else
                    {
                        if (toks[i].pos == null)
                            txtInput.AppendText(toks[i].pron + " ");
                        else
                            txtInput.AppendText(toks[i].pron + "<" + toks[i].pos + ">" + " ");
                    }
                }

                setMessage(aff_count.ToString() + " affixes, " + pref_count.ToString() + " prefixes, " + root_count.ToString() + " roots and " + suff_count.ToString() + " suffixes are found from the lexicon.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private double maxDiac(int w, int t)
        {
            try
            {
                int count = 1;

                maxIndx = 0; max = Double.NegativeInfinity;
                max = score[w, 0] + Convert.ToDouble(langModel[diac[0].ToString() + diac[t].ToString()]);
                while (count < diacLength)
                {
                    curr = score[w, count] + Convert.ToDouble(langModel[diac[count].ToString() + diac[t].ToString()]);

                    if (max < curr)
                    {
                        max = curr;
                        maxIndx = count;
                    }
                    count++;
                }
                return max;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return 0.0;
            }
        }

        private void diacritizationBigramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableDisable(8);
            int pref_len, suff_len;

            try
            {
                diacr_count = 0;

                if (toks == null || toks.Length == 0 || toks_length == 0)
                {
                    setMessage("Untokenize text cannot passed for diacritization.", false);
                    return;
                }

                txtInput.Text = null;

                // probability of unknown
                UKNProb = Convert.ToDouble(langModel["UU"]);

                // sentence tokentization
                for (i = 0; i < toks_length; i++)
                {
                    if (toks[i].done == false)
                    {
                        predictedDiac = null;
                        word = toks[i].word.Insert(0, "+");
                        if (toks[i].pref_diac != null)
                            pref_len = toks[i].pref_diac.Length;
                        else
                            pref_len = 0;

                        if (toks[i].suff_diac != null)
                            suff_len = toks[i].suff_diac.Length;
                        else
                            suff_len = 0;
                        toks[i].pron = null;

                        // datastructures initialization
                        diacritics = null;
                        for (w = 0; w < word.Length + 2; w++)
                        {
                            for (t = 0; t < diacLength; t++)
                            {
                                backPtr[w, t] = 0;
                                score[w, t] = Double.NegativeInfinity;
                            }
                            sequence[w] = 0;
                        } // end datastructures initialization

                        // initialization
                        for (t = 0; t < diacLength; t++)
                        {
                            calc = Convert.ToDouble(diacModel[word[0].ToString() + diac[t].ToString()]);
                            if (calc != 0)
                            {
                                score[0, t] = calc;
                            }
                        } // end initialization

                        // iteration
                        for (w = 1; w < word.Length; w++)
                        {
                            UKN = false;
                            for (t = 0; t < diacLength; t++)
                            {
                                calc = Convert.ToDouble(diacModel[word[w].ToString() + diac[t].ToString()]);
                                if (calc != 0)
                                {
                                    score[w, t] = calc + maxDiac(w - 1, t);
                                    backPtr[w - 1, t] = maxIndx;
                                    UKN = true;
                                }
                            }
                            // Unknown
                            if (!UKN)
                            {
                                for (t = 0; t < diacLength; t++)
                                {
                                    score[w, t] = UKNProb + maxDiac(w - 1, t);
                                    backPtr[w - 1, t] = maxIndx;
                                }
                            } // end unknown
                        } // end iteration

                        // sequence identification
                        max = score[--w, 0];
                        sequence[word.Length - 1] = 0;
                        for (j = 1; j < diacLength; j++)
                        {
                            if (score[w, j] > max)
                            {
                                max = score[w, j];
                                sequence[word.Length - 1] = j;
                            }
                        }
                        predictedDiac = diac[sequence[w]].ToString() + predictedDiac;
                        for (--w; w > 0; w--)
                        {
                            sequence[w] = backPtr[w, sequence[w + 1]];
                            predictedDiac = diac[sequence[w]].ToString() + predictedDiac;
                        }

                        if (pref_len != 0)
                        {
                            diacrit = toks[i].pref_diac;
                            for (w = pref_len; w < toks[i].word.Length; w++)
                                diacrit += predictedDiac[w];
                        }
                        else if (suff_len != 0)
                        {
                            diacrit = predictedDiac;
                            for (w = toks[i].word.Length - suff_len, t = 0; w < toks[i].word.Length; w++, t++)
                            {
                                diacrit = diacrit.Remove(w, 1);
                                diacrit = diacrit.Insert(w, toks[i].suff_diac[t].ToString());
                            }
                        }
                        else
                            diacrit = predictedDiac;

                        if (diacrit[0] == 'ْ')
                        {
                            diacrit = diacrit.Remove(0, 1);
                            diacrit = diacrit.Insert(0, "X");
                        }
                        if (diacrit[diacrit.Length - 1] == 'ْ' && (toks[i].word[toks[i].word.Length - 1] == 'ا' || toks[i].word[toks[i].word.Length - 1] == 'ي' || toks[i].word[toks[i].word.Length - 1] == 'و'))
                        {
                            diacrit = diacrit.Remove(diacrit.Length - 1, 1);
                            diacrit += 'X';
                        }

                        for (w = 0; w < toks[i].word.Length; w++)
                        {
                            if (diacrit[w] != 'X' && diacrit[w] != '#')
                                toks[i].pron = toks[i].pron + toks[i].word[w].ToString() + diacrit[w].ToString();
                            else
                                toks[i].pron = toks[i].pron + toks[i].word[w].ToString();
                        }
                        toks[i].done = true;
                        toks[i].text_color = Color.Red;
                        diacr_count++;
                    }

                    //display
                    txtInput.SelectionColor = toks[i].text_color;
                    if (toks[i].pos != null)
                        txtInput.AppendText(toks[i].pron + "<" + toks[i].pos + ">" + " ");
                    else
                        txtInput.AppendText(toks[i].pron + " "); // end display
                }
                setMessage(diacr_count.ToString() + " words are diacritized statistically.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void diacritizationTrigramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private double maxTag(int w, int t)
        {
            try
            {
                int count = 1;

                maxIndx = 0; max = Double.NegativeInfinity;
                max = score[w, 0] + Convert.ToDouble(POStagPtag[tag[0] + tag[t]]);
                while (count < tag.Length)
                {
                    curr = score[w, count] + Convert.ToDouble(POStagPtag[tag[count] + tag[t]]);

                    if (max < curr)
                    {
                        max = curr;
                        maxIndx = count;
                    }
                    count++;
                }
                return max;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return 0.0;
            }
        }

        private void partofSpeechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start_tok = 0;

            EnableDisable(4);

            try
            {
                pos_count = 0;

                if (toks == null || toks.Length == 0 || toks_length == 0)
                {
                    setMessage("Untokenize text cannot passed to Part-of-Speech tagger.", false);
                    return;
                }

                // probability of unknown
                UKNProb = Convert.ToDouble(POStagPtag["UU"]);

                taggedText = "";
                for (i = 0; i < toks_length; i++)
                {
                    // sentence tokentization
                    words[0] = "۔";
                    start_tok = i;
                    for (j = 1; i < toks_length && toks[i].word != "-" && toks[i].word != "۔" && toks[i].word != "؟" && j < MAX_WORDS - 1; i++, j++)
                    {
                        words[j] = toks[i].word;
                    }
                    if (toks[i].word != "-" || toks[i].word != "۔" || toks[i].word != "؟")
                        words[j] = toks[i].word;
                    else
                        words[i] = "۔";
                    wordLength = ++j; // end sentence tokentization
                    pos_count = pos_count + wordLength - 2;

                    // datastructures initialization
                    for (w = 0; w < wordLength + 5; w++)
                    {
                        for (t = 0; t < tag.Length; t++)
                        {
                            backPtr[w, t] = 0;
                            score[w, t] = Double.NegativeInfinity;
                        }
                        sequence[w] = 0;
                        predictedTag[w] = "";
                    } // end datastructures initialization

                    // initialization
                    for (t = 0; t < tag.Length; t++)
                    {
                        calc = Convert.ToDouble(Convert.ToDouble(POSwordTag[words[0] + tag[t]]));
                        if (calc != 0)
                        {
                            score[0, t] = calc;
                        }
                    } // end initialization

                    // iteration
                    for (w = 1; w < wordLength; w++)
                    {
                        UKN = false;
                        for (t = 0; t < tag.Length; t++)
                        {
                            calc = Convert.ToDouble(POSwordTag[words[w] + tag[t]]);
                            if (calc != 0)
                            {
                                score[w, t] = calc + maxTag(w - 1, t);
                                backPtr[w - 1, t] = maxIndx;
                                UKN = true;
                            }
                        }

                        // unknown
                        if (!UKN)
                        {
                            for (t = 0; t < tag.Length; t++)
                            {
                                score[w, t] = UKNProb + maxTag(w - 1, t);
                                backPtr[w - 1, t] = maxIndx;
                            }
                        } // end unknown
                    } // end iteration

                    // sequence identification
                    max = score[--w, 0];
                    sequence[wordLength - 1] = 0;
                    for (j = 1; j < tag.Length; j++)
                    {
                        if (score[w, j] > max)
                        {
                            max = score[w, j];
                            sequence[wordLength - 1] = j;
                        }
                    }
                    predictedTag[w] += tag[sequence[w]];
                    for (--w; w >= 0; w--)
                    {
                        sequence[w] = backPtr[w, sequence[w + 1]];
                        predictedTag[w] = tag[sequence[w]].ToString();
                    } // end sequence identification

                    //display
                    for (w = 1; w < wordLength; w++, start_tok++)
                    {
                        toks[start_tok].pos = predictedTag[w];
                        taggedText = taggedText + toks[start_tok].word + "<" + toks[start_tok].pos + "> ";
                    } // end display
                }
                txtInput.Text = taggedText;

                isPOStagged = true;

                setMessage("Part-of-Speech tagging is done successfully on " + pos_count + " words.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void testDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] tokens;
            try
            {
                // Generate POS Test corpus files               
                StreamWriter saveWriterRef = new StreamWriter("data\\Test\\POSRef.txt");
                StreamWriter saveWriterCad = new StreamWriter("data\\Test\\POSCad.txt");
                
                String line = (File.OpenText("data\\Test\\TestCorpus.txt")).ReadToEnd();
                (File.OpenText("data\\Test\\TestCorpus.txt")).Close();

                tokens = line.Split('<', '>');

                for (i = 0; i < tokens.Length - 1; i += 2)
                {
                    saveWriterRef.Write(tokens[i + 1].ToUpper());
                    saveWriterRef.Write(saveWriterRef.NewLine);
                }

                for (i = 0; i < toks_length; i++)
                {
                    saveWriterCad.Write(toks[i].pos);
                    saveWriterCad.Write(saveWriterCad.NewLine);
                }

                saveWriterRef.Close();
                saveWriterCad.Close();

                saveWriterRef = new StreamWriter("data\\Test\\DiacRef.txt");
                saveWriterCad = new StreamWriter("data\\Test\\DiacCad.txt");

                for (i = 0; i < tokens.Length - 1; i += 2)
                {
                    saveWriterRef.Write(Diac_Conven_Symbl(unDiacritize(tokens[i]), tokens[i]));
                    saveWriterRef.Write(saveWriterRef.NewLine);
                }

                toks_length = txtInput.Text.Split('<', '>', '\n').Length;
                tokens = txtInput.Text.Split('<', '>', '\n');

                for (i = 0; i < toks_length - 1; i += 2)
                {
                    saveWriterCad.Write(Diac_Conven_Symbl(unDiacritize(tokens[i]), tokens[i]));
                    saveWriterCad.Write(saveWriterCad.NewLine);
                }

                saveWriterRef.Close();
                saveWriterCad.Close();

                setMessage("Test data generated successfully.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void aboutAUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAbout aboutDialog = new frmAbout();
                aboutDialog.ShowDialog();
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        // normalization
        public String normalize(String str)
        {
            try
            {
                str = str.Replace("آ", "آ");
                str = str.Replace("أ", "أ");
                str = str.Replace("ؤ", "ؤ");
                str = str.Replace("ة", "ۃ");
                str = str.Replace("ـ", "");
                str = str.Replace("ك", "ک");
                str = str.Replace("ه", "ہ");
                str = str.Replace("ۂ", "ۂ");
                str = str.Replace("ۀ", "ۂ");
                str = str.Replace("ي", "ی");
                str = str.Replace("٠", "۰");
                str = str.Replace("١", "۱");
                str = str.Replace("٢", "۲");
                str = str.Replace("٣", "۳");
                str = str.Replace("٤", "۴");
                str = str.Replace("٥", "۵");
                str = str.Replace("٦", "۶");
                str = str.Replace("٧", "۷");
                str = str.Replace("٨", "۸");
                str = str.Replace("٩", "۹");
                str = str.Replace("ۓ", "ۓ");
                str = str.Replace("‏", " ");
                str = str.Replace("ٍ", "");
                str = str.Replace("ٍ", "");

                return str;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return null;
            }
        }

        // undiacritize word
        private String unDiacritize(String str)
        {
            try
            {
                if (str.Length == 0 || str == "")
                    return null;

                String str_ret = null;

                for (int i = 0; i < str.Length; i++)
                    if (!(str[i] >= 1611 && str[i] <= 1618) && str[i] != 1622 && str[i] != 1623 && str[i] != 1761 && str[i] != 1648 && str[i] != 65279)
                        str_ret += str[i];

                return str_ret;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return null;
            }
        }

        // load affixes
        private bool loadAffixes(String pFileName, String sFileName)
        {
            int i = 0;
            String[] token;

            try
            {
                // prefix
                String line = (File.OpenText(pFileName)).ReadToEnd();
                (File.OpenText(pFileName)).Close();

                token = line.Split('\n', '\r', '\t');
                for (i = 0; i < token.Length - 1; i += 3)
                {
                    if (token[i] != null)
                    {
                        token[i] = normalize(token[i]);
                        prefixPron.Add(unDiacritize(token[i]), token[i + 1]);
                        prefixDiac.Add(unDiacritize(token[i]), Diac_Convention(token[i], token[i + 1]));
                    }
                }

                // suffix
                line = (File.OpenText(sFileName)).ReadToEnd();
                (File.OpenText(sFileName)).Close();

                token = line.Split('\n', '\r', '\t');
                for (i = 0; i < token.Length; i += 3)
                {
                    if (token[i] != null)
                    {
                        token[i] = normalize(token[i]);
                        suffixPron.Add(unDiacritize(token[i]), token[i + 1]);
                        suffixDiac.Add(unDiacritize(token[i]), Diac_Convention(token[i], token[i + 1]));
                    }
                }
                setMessage("Affixes are loaded successfully.", false);

                return true;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return false;
            }
        }

        // load word list
        private bool loadWordList(String fileName)
        {
            try
            {
                String line = (File.OpenText(fileName)).ReadToEnd();
                (File.OpenText(fileName)).Close();

                String[] tokens = line.Split('\n', '\r');

                for (uint i = 0; i < tokens.Length; i += 2)
                {
                    tokens[i] = unDiacritize(normalize(tokens[i].Trim()));
                    if (tokens[i] != null && !tokLex.ContainsKey(tokens[i]))
                        tokLex.Add(tokens[i], tokens[i]);
                }

                setMessage("Word list is loaded successfully.", false);

                return true;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return false;
            }
        }

        // load close class words lexicon
        private bool loadCloseClassLexicon(String fileName)
        {
            try
            {
                String line = (File.OpenText(fileName)).ReadToEnd();
                (File.OpenText(fileName)).Close();

                String[] tokens = line.Split('\n', '\r', '\t');

                for (uint i = 0; i < tokens.Length; i += 4)
                {
                    tokens[i] = normalize(tokens[i].Trim());
                    if (tokens[i] != null && !ccLex.ContainsKey(tokens[i] + tokens[i + 2]))
                        ccLex.Add(tokens[i] + tokens[i + 2], normalize(tokens[i + 1]));
                }

                setMessage("Close class word lexicon is loaded successfully.", false);

                return true;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return false;
            }
        }

        // load pronunciation lexicon
        private bool loadPronLexicon(String fileName)
        {
            uint i;
            String line;
            String[] tokens;

            try
            {
                line = (File.OpenText(fileName)).ReadToEnd();
                (File.OpenText(fileName)).Close();

                tokens = line.Split('\n', '\r', '\t');

                for (i = 0; i < tokens.Length; i += 5)
                {
                    if (tokens[i] != null && tokens[i].Length > 0 && !pronPOSLex.ContainsKey(tokens[i] + tokens[i + 3]) && tokens[i].Length == tokens[i + 1].Length)
                    {
                        line = null;
                        for (w = 0; w < tokens[i].Length; w++)
                        {
                            if (tokens[i + 2][w] != 'X' && tokens[i + 2][w] != '#')
                                line = line + tokens[i][w].ToString() + tokens[i + 2][w].ToString();
                            else
                                line = line + tokens[i][w].ToString();
                        }
                        pronPOSLex.Add(tokens[i] + tokens[i + 3], line);
                        
                        if (!pronLex.ContainsKey(tokens[i]))
                            pronLex.Add(tokens[i], line);
                    }
                }

                setMessage("Pronunciation lexicon of " + pronPOSLex.Count + " is loaded successfully.", false);

                return true;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return false;
            }
        }

        // load pronunciation corpus
        private bool loadPronCorpus(String fileName)
        {
            uint i;
            String line, tok, prev_tok;
            String[] tokens;

            try
            {
                line = (File.OpenText(fileName)).ReadToEnd();
                (File.OpenText(fileName)).Close();

                tokens = line.Split('<', '>');

                for (i = 2; i < tokens.Length; i += 2)
                {
                    tokens[i] = normalize(tokens[i].Trim());
                    tokens[i - 2] = normalize(tokens[i - 2].Trim());
                    tok = unDiacritize(tokens[i]);
                    prev_tok = unDiacritize(tokens[i - 2]);

                    if (prev_tok != null)
                        prev_tok = normalize(prev_tok);

                    if (tokens[i] != null && tokens[i].Length > 0 && !pronCor.ContainsKey(prev_tok + tok))
                        pronCor.Add(prev_tok + tok, tokens[i]);
                }

                setMessage("Pronunciation corpus of " + pronCor.Count + " is loaded successfully.", false);

                return true;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return false;
            }
        }

        // load diacritics, alphabet diacritics, and diacritics pdiacritics probabilities
        private bool loadDiacProb(String diacFile, String diacModelFile, String langModelFile)
        {
            uint i = 0;
            String line;
            String[] tokens;

            try
            {
                // Diacritics
                line = (File.OpenText(diacFile)).ReadToEnd();
                (File.OpenText(diacFile)).Close();

                tokens = line.Split('\n', '\r');
                while (i < tokens.Length - 1)
                {
                    if (tokens[i] != null)
                        diac += tokens[i][0];
                    i += 2;
                }
                diacLength = diac.Length;

                // P(a(i) | d(i-1)) = [count(a(i) . d(i)) / count(d(i))]
                line = (File.OpenText(diacModelFile)).ReadToEnd();
                (File.OpenText(diacModelFile)).Close();

                tokens = line.Split('\n', '\r', '\t');
                for (i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i].Length != 0 && !diacModel.ContainsKey(tokens[i] + tokens[i + 1]))
                        diacModel.Add(tokens[i] + tokens[i + 1], Math.Log10(Convert.ToDouble(tokens[i + 2]) / 10000.0));
                    i += 3;
                }

                // P(d(i) | d(i-1)) = [count(d(i-1) . d(i)) / count(d(i-1))]
                line = (File.OpenText(langModelFile)).ReadToEnd();
                (File.OpenText(langModelFile)).Close();

                tokens = line.Split('\n', '\r', '\t');
                for (i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i].Length != 0 && !langModel.ContainsKey(tokens[i] + tokens[i + 1]))
                        langModel.Add(tokens[i] + tokens[i + 1], Math.Log10(Convert.ToDouble(tokens[i + 2]) / 10000.0));
                    i += 3;
                }

                setMessage("Diacritization probabilities loaded successfully.", false);

                return true;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return false;
            }
        }

        // load part-of-speech tags, word tag, and tag ptag probabilities
        private bool loadPOSProb(String tagFileName, String wordTagFileName, String tagTagFileName)
        {
            int i, j = 0;
            String line;
            String[] tokens;

            try
            {
                // part-of-speech tags
                line = (File.OpenText(tagFileName)).ReadToEnd();
                (File.OpenText(tagFileName)).Close();

                tokens = line.Split('\n', '\r');
                for (i = 0; i < tokens.Length; i++)
                {
                    tokens[i] = tokens[i].Trim();
                    if (tokens[i].Length != 0)
                        tag[j++] = tokens[i];
                    i++;
                }
                diacLength = j;

                // word tag probabilities
                line = (File.OpenText(wordTagFileName)).ReadToEnd();
                (File.OpenText(wordTagFileName)).Close();

                tokens = line.Split('\n', '\r', '\t');
                for (i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i].Length != 0)
                    {
                        tokens[i] = tokens[i].Trim();
                        tokens[i + 1] = tokens[i + 1].Trim();
                        tokens[i + 2] = tokens[i + 2].Trim();
                        if (!POSwordTag.ContainsKey(tokens[i] + tokens[i + 1]))
                            POSwordTag.Add(tokens[i] + tokens[i + 1], Math.Log10(Convert.ToDouble(tokens[i + 2]) * 1000.0));
                    }
                    i += 3;
                }

                // tap ptag probabilities
                line = (File.OpenText(tagTagFileName)).ReadToEnd();
                (File.OpenText(tagTagFileName)).Close();

                tokens = line.Split('\n', '\r', '\t');
                for (i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i].Length != 0)
                    {
                        tokens[i] = tokens[i].Trim();
                        tokens[i + 1] = tokens[i + 1].Trim();
                        tokens[i + 2] = tokens[i + 2].Trim();
                        if (!POStagPtag.ContainsKey(tokens[i] + tokens[i + 1]))
                            POStagPtag.Add(tokens[i] + tokens[i + 1], Math.Log10(Convert.ToDouble(tokens[i + 2]) * 1000.0));
                    }
                    i += 3;
                }

                setMessage("Part-of-Speech probabilities loaded successfully.", false);
                
                return true;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return false;
            }
        }

        public String Diac_Convention(String word, String pron)
        {
            String diac_word = null;
            String undiac_word = unDiacritize(word);
            String diac = diacritics_symbol(pron);
            int i;

            try
            {
                for (i = 0; i < diac.Length; i++)
                {
                    if (diac[i] == 1614)
                        diac_word += 'َ';
                    else if (diac[i] == 1616)
                        diac_word += 'ِ';
                    else if (diac[i] == 1615)
                        diac_word += 'ُ';
                    else if (diac[i] == 1618)
                        diac_word += 'ْ';
                    else if (diac[i] == 1617)
                        diac_word += 'ّ';
                    else if (diac[i] == 1611)
                        diac_word += 'ً';
                    else if (diac[i] == 1777)
                        diac_word += 'ٰ';
                    else if (diac[i] == 'O')
                        diac_word += 'X';
                    else if (diac[i] == 32)
                    {
                        if (diac[i - 1] != 32)
                            diac_word += ' ';
                        if (diac[i + 1] == 32)
                            i++;
                        i++;
                    }
                }

                if (diac_word.Length == unDiacritize(pron).Length)
                    return diac_word;
                else
                    return null;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return null;
            }
        }

        public String Diac_Conven_Symbl(String word, String pron)
        {
            int i;
            String diac_word = null;
            String diac = null;

            pron = pron.Replace("ّ", "");
            pron = pron.Replace("ً", "");
            pron = pron.Replace("ٰ", "");
         
            diac = diacritics_symbol(pron);

            try
            {
                for (i = 0; i < diac.Length; i++)
                {
                    if (diac[i] == 1614)
                        diac_word += 'Z';
                    else if (diac[i] == 1616)
                        diac_word += 'R';
                    else if (diac[i] == 1615)
                        diac_word += 'P';
                    else if (diac[i] == 1618)
                        diac_word += 'J';
                    /*else if (diac[i] == 1617)
                        ;//diac_word += 'S';
                    else if (diac[i] == 1611)
                        ;//diac_word += 'D';
                    else if (diac[i] == 1777)
                        ;//diac_word += 'K';*/
                    else if (diac[i] == 'O')
                        diac_word += 'X';
                    else if (diac[i] == 32)
                    {
                        if (diac[i - 1] != 32)
                            diac_word += ' ';
                        if (diac[i + 1] == 32)
                            i++;
                        i++;
                    }
                }

                if (diac_word.Length == unDiacritize(pron).Length)
                    return diac_word;
                else
                    return null;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return null;
            }
        }

        public String diacritics_symbol(String str)
        {
            int i = 0, j = 1;

            try
            {
                if (str.Length == 0 || str == "")
                    return null;

                j = 1;
                for (i = 0; i < str.Length; i++)
                {
                    if (i % 2 == j)
                    {
                        if (!(str[i] >= 1611 && str[i] <= 1618) && str[i] != 1622 && str[i] != 1623 && str[i] != 1761 && str[i] != 65279)
                        {
                            str = str.Insert(i, "O");
                            if (str[i + 1] == 32 && j == 1)
                            {
                                j = 0;
                                i++;
                            }
                            if (str[i + 1] == 32 && j == 0)
                            {
                                j = 1;
                                i++;
                            }
                        }
                    }
                }
                i--;
                if (!(str[i] >= 1611 && str[i] <= 1618) && str[i] != 1622 && str[i] != 1623 && str[i] != 1761 && str[i] != 65279)
                    str = str.Insert(i + 1, "O");

                return str;
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
                return null;
            }
        }

        private void WSD(String fileName)
        {
            int count = 0;
            String[] tokens;
            Hashtable wordPron = new Hashtable();

            try
            {
                String line = (File.OpenText(fileName)).ReadToEnd();
                (File.OpenText(fileName)).Close();

                tokens = line.Split('<', '>');

                for (i = 0; i < tokens.Length; i += 2)
                {
                    if (tokens[i] != null && tokens[i].Length > 0 && !wordPron.ContainsKey(unDiacritize(normalize(tokens[i]))))
                    {
                        wordPron.Add(unDiacritize(normalize(tokens[i])), normalize(tokens[i]));
                    }
                    else
                    {
                        if (wordPron[unDiacritize(normalize(tokens[i]))].ToString() != normalize(tokens[i]))
                            count++;
                    }
                }

                setMessage(((Convert.ToDouble(count) / (Convert.ToDouble(tokens.Length / 2))) * 100.0) + " % WSD words are found.", false);
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        private void EnableDisable(int item)
        {
            try
            {
                switch (item)
                {
                    case 0:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 1:
                        normalizationToolStripMenuItem.Checked = true;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 2:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = true;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 3:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = true;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 4:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = true;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 5:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = true;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 6:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = true;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 7:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = true;
                        diacritizationBigramToolStripMenuItem.Checked = false;
                        break;
                    case 8:
                        normalizationToolStripMenuItem.Checked = false;
                        undiacritizationToolStripMenuItem.Checked = false;
                        tokenizationToolStripMenuItem.Checked = false;
                        partofSpeechToolStripMenuItem.Checked = false;
                        searchFromCorpusToolStripMenuItem.Checked = false;
                        searchFromLexiconToolStripMenuItem.Checked = false;
                        morphemesToolStripMenuItem.Checked = false;
                        diacritizationBigramToolStripMenuItem.Checked = true;
                        break;
                }
            }
            catch (Exception caught)
            {
                setMessage(caught.Message, true);
            }
        }

        public void setMessage(String message, bool isBeep)
        {
            try
            {
                statusBar.Text = message;
                if (isBeep)
                    SystemSounds.Hand.Play();
                else
                    SystemSounds.Asterisk.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, projectName);
            }
        }
    }

    public class Lexicon
    {
        public String word;
        public String pron;
        public String diac;
        public String pos;
        public String pref_diac;
        public String suff_diac;
        public Boolean done;
        public Color text_color;

        public Lexicon()
        {
            word = null;
            pron = null;
            diac = null;
            pos = null;
            pref_diac = null;
            suff_diac = null;
            done = false;
            text_color = Color.Black;
        }

        public Lexicon(String Word, String Pron, String Diac, String Pos, String pref_D, String suff_D, Boolean Done, Color text_Color)
        {
            word = Word;
            pron = Pron;
            diac = Diac;
            pos = Pos;
            pref_diac = pref_D;
            suff_diac = suff_D;
            done = Done;
            text_color = text_Color;
        }
    }
}