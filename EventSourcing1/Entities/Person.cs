using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventSourcing1
{
    public partial class Person : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }
        public Person()
        {
        }
    }
}