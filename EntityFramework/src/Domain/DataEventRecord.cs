using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class DataEventRecord
    {
        public DataEventRecord()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SourceInfo SourceInfo { get; private set; }
    }
}
