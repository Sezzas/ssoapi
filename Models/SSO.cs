using System.ComponentModel.DataAnnotations;

namespace ssoapi.Models {

    // Horses
    public class Horse {

        // Properties
        public int HorseId { get; set; } // ID

        [Required]
        public string? Name { get; set; } // Name

        public string? Nickname { get; set; } // Nickname

        [Required]
        public string? Gender { get; set; } // Gender

        [Required]
        public string? Breed { get; set; } // Breed

        [Required]
        public int Level { get; set; } // Level

        [Required]
        public string? Owner { get; set; } // Owner

        public string? Picture { get; set; } // Picture

        [DataType(DataType.Text)]
        public string? Info { get; set; } // Info

    }

    // Notes
    public class Note {

        // Properties
        public int NoteId { get; set; } // ID

        [Required]
        public string? Title { get; set; } // Title

        [Required]
        [DataType(DataType.Text)]
        public string? Content { get; set; } // Content

    }


    // News
    public class News {

        // Properties
        public int NewsId { get; set; } // ID

        [Required]
        public string? Title { get; set; } // Title

        [Required]
        [DataType(DataType.Text)]
        public string? Content { get; set; }  // Content

    }

}