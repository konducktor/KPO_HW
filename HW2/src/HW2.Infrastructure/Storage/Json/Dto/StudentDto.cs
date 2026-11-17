namespace HW2.Infrastructure;

internal record StudentDto(int Id, string Name, string Surname, List<ScoreDto> Scores);
