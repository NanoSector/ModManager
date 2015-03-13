using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mod_Builder.Classes
{
    [Serializable()]
    public class Project : IProject
    {
        public bool isOnDisk {get; set;}

        public Project()
        {
            this.isOnDisk = false;
        }
    }
}
