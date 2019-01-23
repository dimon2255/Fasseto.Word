using System.ComponentModel.DataAnnotations;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Settings Database table representational model
    /// </summary>
    public class SettingsDataModel
    {
        /// <summary>
        /// Unique Id for this entry
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Setting's name
        ///<summary>
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Settings value
        /// </summary>
        [MaxLength(2048)]
        [Required]
        public string Value { get; set; }

    }
}
