﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPrintService" in both code and config file together.
    [ServiceContract]
    public interface IPrintService
    {
        [OperationContract]
        void DoWork();
    }
}