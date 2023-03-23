﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Entities
{
    public class ImageEntity
    {
        [Key]
        public int ImageID { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public PostEntity Post { get; set; }

    }
}
