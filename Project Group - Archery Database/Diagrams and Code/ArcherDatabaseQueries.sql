CREATE TABLE IF NOT EXISTS Archer (
    ArcherID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Age INT NOT NULL,
    Gender VARCHAR(255) NOT NULL,
    DivisionName VARCHAR(255) NOT NULL,
	EquipmentType ENUM('Recurve', 'Compound', 'Recurve Barebow', 'Compound Barebow', 'Longbow') NOT NULL
);

CREATE TABLE IF NOT EXISTS Rounds (
    RoundID INT PRIMARY KEY AUTO_INCREMENT,
    RoundName VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS Ranges (
    RangeID INT PRIMARY KEY AUTO_INCREMENT,
	RoundID INT NOT NULL,
    Distance INT NOT NULL,
	EndCount INT NOT NULL,
    TargetFaceSize ENUM('80', '122') NOT NULL,
    FOREIGN KEY (RoundID) REFERENCES Round(RoundID)
);

CREATE TABLE IF NOT EXISTS Arrow (
    ArrowID INT PRIMARY KEY AUTO_INCREMENT,
    ScoreID INT NOT NULL,
	Score INT NOT NULL,
	EndNumber INT NOT NULL,
	ArrowNumber INT NOT NULL,
    FOREIGN KEY (ScoreID) REFERENCES Score(ScoreID)
);

CREATE TABLE IF NOT EXISTS Score (
    ScoreID INT PRIMARY KEY AUTO_INCREMENT,
    ScoreDate DATE NOT NULL, 
	ArcherID INT NOT NULL,
    RoundID INT NOT NULL,
    FOREIGN KEY (ArcherID) REFERENCES Archer(ArcherID),
	FOREIGN KEY (RoundID) REFERENCES Rounds(RoundID)
);

CREATE TABLE IF NOT EXISTS Definitions (
    CompetitionID INT PRIMARY KEY AUTO_INCREMENT,
    CompetitionName VARCHAR(255),
	CompetitionDate Date,
    RoundID INT NOT NULL,
	ScoreID INT NOT NULL,
    FOREIGN KEY (RoundID) REFERENCES Rounds(RoundID),
	FOREIGN KEY (ScoreID) REFERENCES Score(ScoreID)
);

CREATE TABLE IF NOT EXISTS EquivalentRound (
   	EquivalentRoundID INT PRIMARY KEY AUTO_INCREMENT,
    RoundID INT NOT NULL,
	EquivalentRoundName VARCHAR(255),
    StartDate Date NOT NULL,
	EndDate Date NOT NULL,
    FOREIGN KEY (RoundID) REFERENCES Rounds(RoundID)
);

/*Queries*/ /*<###> means the data within <> needs to be filled by the required fields*/

/*archer score lookup*/
SELECT archer.FirstName, archer.LastName, score.ScoreID, score.ScoreDate, rounds.RoundName, SUM(arrow.Score) AS TotalScore
FROM Score
JOIN Rounds ON score.RoundID = rounds.RoundID
JOIN Archer ON score.ArcherID = archer.ArcherID
JOIN Arrow ON score.ScoreID = arrow.ScoreID
WHERE score.ArcherID = <ArcherID>
AND score.ScoreDate BETWEEN <StartDate> AND <EndDate>
AND rounds.RoundName = <RoundName>
ORDER BY score.ScoreDate DESC; 

/*round definitions*/
SELECT rounds.RoundName, ranges.Distance, ranges.EndCount, ranges.TargetFaceSize
FROM Rounds
JOIN Ranges ON rounds.RangeID = ranges.RoundID
WHERE rounds.RoundID = <RoundID>;

/*equivalent rounds*/
SELECT EquivalentRoundName
FROM EquivalentRound
WHERE RoundId = <RoundID>
AND StartDate <= <StartDate> AND EndDate >= <EndDate>

/*competition results*/
SELECT definitions.CompetitionName, archer.FirstName, archer.LastName, SUM(arrow.Score) AS TotalScore
FROM Definitions
JOIN Score ON definitions.ScoreID = score.ScoreID
JOIN Archer ON score.ArcherID = archer.ArcherID
JOIN Arrow ON score.ScoreID = arrow.ScoreID
GROUP BY definitions.CompetitionName, archer.FirstName, archer.LastName
ORDER BY definitions.CompetitionName, TotalScore DESC;

/*club competiion*/
SELECT definitions.CompetitionName, archer.FirstName, archer.LastName, SUM(arrow.Score) AS TotalScore,
  RANK() OVER (PARTITION BY definitions.CompetitionID ORDER BY SUM(arrow.Score) DESC) AS Placing
FROM Definitions
JOIN Score ON definitions.ScoreID = score.ScoreID
JOIN Archer ON score.ArcherID = archer.ArcherID
JOIN Arrow ON score.ScoreID = arrow.ScoreID
WHERE definitions.CompetitionName = <CompetitionName>
GROUP BY definitions.CompetitionID, archer.ArcherID;

/*PB Score*/
SELECT archer.FirstName, archer.LastName, round.RoundName, MAX(TotalScore) AS PB
FROM (
  SELECT score.ArcherId, score.RoundId, SUM(arrow.Score) AS TotalScore
  FROM Score
  INNER JOIN Arrow ON score.ScoreId = arrow.ScoreId
  WHERE score.ArcherId = <ArcherID> 
  AND score.RoundId = <RoundID>
  GROUP BY Score.ScoreId
)
JOIN Archer ON archer.ArcherId = archer.ArcherId
JOIN Round ON round.RoundId = round.RoundId
ORDER BY PB DESC
LIMIT 1;

/*club best*/
SELECT archer.FirstName, archer.LastName, round.RoundName, MAX(TotalScore) AS ClubPB
FROM (
  SELECT score.ArcherId, score.RoundId, SUM(arrow.Score) AS TotalScore
  FROM Score
  INNER JOIN Arrow ON score.ScoreId = arrow.ScoreId
  WHERE score.RoundId = <RoundID>
  GROUP BY Score.ScoreId
)
JOIN Archer ON archer.ArcherId = archer.ArcherId
JOIN Round ON round.RoundId = round.RoundId
ORDER BY ClubPB DESC
LIMIT 1;

/*Indexes*/

CREATE INDEX IndexArcherID_Archer ON Archer (ArcherID);

CREATE INDEX IndexArcherID_Score ON Score (ArcherID);
CREATE INDEX IndexRoundID_Score ON Score (RoundID);

CREATE INDEX IndexRoundID_Definitions ON Definitions (RoundID);
CREATE INDEX IndexScoreID_Definitions ON Definitions (ScoreID);

CREATE INDEX IndexRoundID_Rounds ON Rounds (RoundID);

CREATE INDEX IndexRoundID_Ranges ON Ranges (RoundID);
