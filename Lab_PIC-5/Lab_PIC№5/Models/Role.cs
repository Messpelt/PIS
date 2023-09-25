﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Models
{
    class Role
    {
        public string Name { get; set; }
        public Dictionary<NameMdels, bool> CheckPosibilitis { get; set; }

        public Role(string name, Dictionary<NameMdels, bool> checkPosibilitis)
        {
            CheckPosibilitis = checkPosibilitis;
            Name = name;
        }
    }

    enum NameMdels
    {
        Act,
        App,
        Contract,
        Org,
        Report
    }
}
