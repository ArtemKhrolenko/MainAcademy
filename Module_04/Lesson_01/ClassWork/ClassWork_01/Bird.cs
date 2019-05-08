using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Bird
    {
        public int FlySpeed { get; set; }
        public int NormalSpeed { get; set; }
        public string Nick { get; set; }
        
        //Bird flew away, isn't it?

        private bool birdFlewAway;
        public int crit_diff;

        //The bird states       

        public event BirdEventsHandler Startle;

        //The delegate for the bird's events
        public delegate void BirdEventsHandler(object sender, BirdEventsArgs e);
        public event BirdEventsHandler NotSeeing;

        protected virtual void OnNotSeeing(BirdEventsArgs e)
        {
            NotSeeing?.Invoke(this, e);
        }

        public Bird() {
        FlySpeed = 35;
        crit_diff = 3;
        Nick= "Titmouse";
        }
        public Bird( string name,int extrim_speed, int speed, int diff )
        {
            NormalSpeed = speed;
            FlySpeed = extrim_speed;
            Nick = name;
            crit_diff = diff;
        }


        public void FlyAway(int incrmnt)
        {
            if (birdFlewAway)
            {
                if(NotSeeing != null)
                {
                    BirdEventsArgs ev = new BirdEventsArgs("Птица улетает");
                    ev.BirdFlewAway = birdFlewAway;
                    ev.TimeReached = DateTime.Now;

                    OnNotSeeing(ev);
                }
            }
            else
            {
                NormalSpeed += incrmnt;
                if ((crit_diff >= FlySpeed - NormalSpeed) && (Startle != null))
                {
                    Startle(this, new BirdEventsArgs(Nick.ToString() + " Panic"));
                }
            }
            if (NormalSpeed >= FlySpeed)
                birdFlewAway = true;
            else
                Console.WriteLine("...flying close with the speed = {0}", NormalSpeed);
        }

    }

    public class BirdEventsArgs : EventArgs
    {
        public readonly string eventString;
        public BirdEventsArgs(string someStr)
        {
            eventString = someStr;
        }

        public bool BirdFlewAway { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
