CREATE TABLE IF NOT EXISTS  Archer (
    ArcherID INT NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Age INT,
    Gender VARCHAR(255),
    ClassName VARCHAR(255),
    PRIMARY KEY (ArcherID)
);

CREATE TABLE IF NOT EXISTS Arrow (
    ArrowID INT NOT NULL AUTO_INCREMENT,
    Score INT,
    ArrowTime INT,
    PRIMARY KEY (ArrowID)
);

CREATE TABLE IF NOT EXISTS ScoreList (
    ScoreID INT NOT NULL AUTO_INCREMENT,
    Score INT,
    ArrowID INT NOT NULL,
    PRIMARY KEY (ScoreID),
    FOREIGN KEY (ArrowID) REFERENCES Arrow(ArrowID)
);

CREATE TABLE IF NOT EXISTS  Participant (
    ParticipantID INT NOT NULL AUTO_INCREMENT,
    ArcherID INT NOT NULL,
    EquipmentName ENUM( 'Recurve', 'Compound', 'RecurveCompound Barebow', 'Longbow', 'Default' ),
    PRIMARY KEY (ParticipantID),
    FOREIGN KEY (ArcherID) REFERENCES Archer(ArcherID)
);

CREATE TABLE IF NOT EXISTS RangeList (
    RangeID INT NOT NULL AUTO_INCREMENT,
    NumArrows ENUM('30', '36'),
    Distance INT NOT NULL,
    TargetFace INT NOT NULL CHECK (TargetFaceSize IN (80, 122)),
    DateRecord DATE,
    ParticipantID INT NOT NULL,
    PRIMARY KEY (RangeID),
    FOREIGN KEY (ParticipantID) REFERENCES Participant(ParticipantID)
);

CREATE TABLE IF NOT EXISTS Rounds (
    RoundID INT NOT NULL AUTO_INCREMENT,
    RoundName VARCHAR(255) NOT NULL,
    RangeID INT NOT NULL,
    PRIMARY KEY (RoundID),
    FOREIGN KEY (RangeID) REFERENCES RangeList(RangeID)
);

CREATE TABLE IF NOT EXISTS Defenitions (
    CompetitionID INT NOT NULL,
    CompetitionName VARCHAR(255),
    RoundID INT NOT NULL,
    PRIMARY KEY (CompetitionID),
    FOREIGN KEY (RoundID) REFERENCES Rounds(RoundID)
);

INSERT INTO Archer (ArcherID, FirstName, LastName, Age, Gender, ClassName)
VALUES (1, 'Tomjeer', 'Apple', 23, 'Male', 'Norway');
