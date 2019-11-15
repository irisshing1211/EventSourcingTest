using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventSourcing1
{
    public class LogHistory: BaseEntity
    {
      
        public string Message { get; set; }
       
    }
}