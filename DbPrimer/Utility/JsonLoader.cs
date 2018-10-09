using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbPrimer.Utility
{
    public class JsonLoader
    {
        public static List<HackingTarget> Load(string dir)
        {
            List<HackingTarget> items = new List<HackingTarget>();

            using (StreamReader r = new StreamReader(dir))
            {
                string json = r.ReadToEnd();
               items = JsonConvert.DeserializeObject<List<HackingTarget>>(json);
            }

            return items;
        }
    }
    
    public class HackingTarget
    {
        public int Id = 0;
        public string Name = "";
        public string Handle = "";
        public string URL = "";
        public bool Offers_bounties = false;
        public bool Quick_to_bounty = false;
        public bool Quick_to_first_response = false;
        public Targets Targets;
    }
    
    public class Targets
    {
        public Target[] in_scope;
        public Target[] out_of_scope;
    }
    
    public class Target
    {
        public string asset_identifier = "";
        public string asset_type = "";
        public string availability_requirement = "";
        public string confidentiality_requirement = "";
        public string eligible_for_bounty = "";
        public string eligible_for_submission = "";
        public string instruction = "";
        public string integrity_requirement = "";
        public string max_severity = "";

        public string type = "";
        public string target = "";
    } 
}