﻿using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_web_app2.Models
{
    public class Devices
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int device_Id { get; set; }

        
       public string device_Name { get; set; }
    }

    
}
