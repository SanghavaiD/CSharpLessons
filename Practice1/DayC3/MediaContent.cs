using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayThree
{
    internal class MediaContent
    {
        public virtual void StartPlayingContent()
        {
            Console.WriteLine("Start");
        }
        public virtual void StopPlayingContent()
        {
            Console.WriteLine("Stop");
        }
        public virtual void PausePlayingContent()
        {
            Console.WriteLine("Pause");
        }
        public virtual void ContinuePlayingContent()
        {
            Console.WriteLine("Continue");
        }
        public override sealed string ToString()
        {
            Console.WriteLine("Media ToString");
            return "OTT";
        }
    }
    //End of Media Class
    internal class AudioContent:MediaContent
    {
        public override sealed void StartPlayingContent()
        {
            Console.WriteLine("Start");
        }
         //public override string ToString()
        // {
          // Console.WriteLine("Media ToString");
           //return "OTT";
         //}
    }
    //End of AudioContent Class
    internal class VideoContent : AudioContent
    {
        //public override sealed void StartPlayingContent()
        //{
        //  Console.WriteLine("Start");
        //}
    }
    //End of VideoContent Class
    
    internal class MediaTester
    {
        public static void TestOne()
        {

        }
    }
    //End of MediaTesterClass

}
