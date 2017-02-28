using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SourceInfo
    {
        private readonly HashSet<DataEventRecord> _dataEventRecords;

        public SourceInfo()
        {
            Id = Guid.NewGuid();
            _dataEventRecords = new HashSet<DataEventRecord>();
        }

        [Key]
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<DataEventRecord> DataEventRecords => _dataEventRecords;

        public void AddDataEventRecord(DataEventRecord dataEventRecord)
        {
            _dataEventRecords.Add(dataEventRecord);
        }
    }
}
