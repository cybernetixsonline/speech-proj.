using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace CybernetixOnline
{
    class ModulRec
    {
        public Universe univers;
        public ModulRec(Universe univers)
        {
            this.univers = univers;
            this.univers.modulRec = this;
        }

        SpeechRecognitionEngine speechRec = new SpeechRecognitionEngine();
        SpeechSynthesizer speechSynt = new SpeechSynthesizer();
               
        public void Run()
        {
            speechSynt.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 16);
            speechSynt.Rate = -1;
            speechSynt.Volume = 80;
            Sonjasay("Voice lowding");

            LoardeGrammer();

            speechRec.SetInputToDefaultAudioDevice();
            speechRec.RecognizeAsync(RecognizeMode.Multiple);

            speechRec.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Ausgabe_audioin);

            speechSynt.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(Speech_start);
            speechSynt.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(Speech_stop);

        }

        private void LoardeGrammer()
        {
            DictationGrammar dictation = new DictationGrammar();
            speechRec.LoadGrammar(dictation);
        }

        private void Speech_stop (object sender,SpeakCompletedEventArgs e)
        {
            // ausgabe stop
        } 

        private void Speech_start(object sender, SpeakStartedEventArgs e)
        {
            // ausgabe start
        }

        
        private void Ausgabe_audioin(object sender, SpeechRecognizedEventArgs e)
        {
            // ausgabe der audio dat
            string speechResp;
            speechResp = e.Result.Text;
            univers.form1.lblAusgabe.Text = speechResp;
            switch (speechResp)
            {
                
            }
        }

        public void Sonjasay(string ssay)
        {
            speechSynt.SpeakAsync(ssay);
        }
    }
}
