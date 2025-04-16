using shared.Enums;
using System.Text.Json.Serialization;

namespace shared.Dtos
{
    public class StartSessionRequestDto
    {
        public int CollectionId { get; set; }
        [JsonPropertyName("studySessionMode")]
        public StudySessionMode StudySessionMode { get; set; }
    }
}