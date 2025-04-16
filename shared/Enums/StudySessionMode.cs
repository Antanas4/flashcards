using System.Text.Json.Serialization;
namespace shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StudySessionMode
    {
        BasicReview,
        CorrectStreak
    }
}