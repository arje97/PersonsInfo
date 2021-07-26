﻿using System.Collections.Generic;

namespace Core.Domain
{
    public  class PhoneNumber
    {
        public int Id { get; set; }
        public NumberType NumberType { get; set; }
        public string Number { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
