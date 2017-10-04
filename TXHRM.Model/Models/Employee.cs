﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string IDCardNo { get; set; }
        public DateTime DateIssued { get; set; }
        public string PlaceIssued { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public int DepartmentID { get; set; }

        public long LeaderID { get; set; }

        public int PositionID { get; set; }

        //Navigation Properties
        public virtual ICollection<WorkingProcess> WorkingProcesses { get; set; }

        [ForeignKey("PositionID")]
        public virtual Position Position { get; set; }

        [ForeignKey("LeaderID")]
        public virtual Employee Leader { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
    }
}
