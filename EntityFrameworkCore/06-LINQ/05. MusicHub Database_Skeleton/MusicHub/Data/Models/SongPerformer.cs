﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }

        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }
        public virtual Performer Performer { get; set; }
    }
}
