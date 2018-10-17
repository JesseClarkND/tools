using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternateTerritory.Models
{
    public class ScannerContext
    {
        public string Domain = "";
        public List<Vulnerability> FoundVulnerabilities = new List<Vulnerability>();
    }
}