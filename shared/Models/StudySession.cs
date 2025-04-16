using System.ComponentModel.DataAnnotations;
using shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace shared.Models
{
    public class StudySession
    {
        private int _id;
        private StudySessionMode _studySessionode;
        private bool _isCompleted;
        private List<StudySessionFlashcard> _flashcards;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        [Column("Mode")]
        public StudySessionMode StudySessionMode
        {
            get => _studySessionode;
            set => _studySessionode = value;
        }
        public bool IsCompleted
        {
            get => _isCompleted;
            set => _isCompleted = value;
        }
        public List<StudySessionFlashcard> Flashcards
        {
            get => _flashcards;
            set => _flashcards = value;
        }
    }

}
