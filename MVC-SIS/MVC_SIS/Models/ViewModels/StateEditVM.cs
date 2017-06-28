using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.ViewModels
{
    public class StateEditVM
    {
        public string OldStateAbbrev { get; set; }
        public State NewState { get; set; }

    }
}