USE master
GO

CREATE DATABASE Patient_DB
GO

USE Patient_DB
GO

CREATE TABLE Diseases
(
    DiseasesId INT IDENTITY PRIMARY KEY,
    DiseasesName NVARCHAR(50) NOT NULL
)
GO

INSERT INTO Diseases VALUES
('Ischemic Heart Disease'),
('Stroke'),
('Influenza or Flu'),
('Pneumonia'),
('Alzheimer’s disease'),
('Arthritis'),
('Angina'),
('Anorexia nervosa'),
('Anxiety disorders')
GO

SELECT * FROM Diseases
GO

CREATE TABLE Patient
(
    PatientId INT IDENTITY PRIMARY KEY,
    PatientName NVARCHAR(50) NOT NULL,
    DiseasesId INT NOT NULL,
    Epilepsy INT NOT NULL,
    FOREIGN KEY (DiseasesId) REFERENCES Diseases(DiseasesId)
);

INSERT INTO Patient VALUES
('Lorem',9,2),
('Amet',2,2)
GO

SELECT * FROM Patient
GO

CREATE TABLE NCD
(
    NCDId INT IDENTITY PRIMARY KEY,
    NCDName NVARCHAR(50) NOT NULL
);

INSERT INTO NCD VALUES
('Asthma'),
('Cancer'),
('Disorders of ear'),
('Disorder of eye'),
('Mental illness'),
('Oral helth problems')
GO

SELECT * FROM NCD
GO

CREATE TABLE NCD_Details
(
    Id INT IDENTITY PRIMARY KEY,
    PatientId INT NULL,
    NCDId INT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId),
    FOREIGN KEY (NCDId) REFERENCES NCD(NCDId)
)
GO

INSERT INTO NCD_Details VALUES
(1,3),
(1,5),
(2,4),
(2,5)
GO

SELECT * FROM NCD_Details
GO

CREATE TABLE Allergies
(
    AllergiesId INT IDENTITY PRIMARY KEY,
    AllergiesName NVARCHAR(50) NOT NULL
)
GO

INSERT INTO Allergies VALUES
('Drugs - Penicillin'),
('Drusg - Others'),
('Animals'),
('Food'),
('Oniments'),
('Plant'),
('Sprays'),
('Others'),
('No Allergies')
GO

SELECT * FROM Allergies
GO

CREATE TABLE AllergiesDetails
(
    Id INT IDENTITY PRIMARY KEY,
    PatientId INT NULL,
    AllergiesId INT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId),
    FOREIGN KEY (AllergiesId) REFERENCES Allergies(AllergiesId)
)
GO

INSERT INTO AllergiesDetails VALUES
(1,4),
(1,7),
(2,8)
GO

SELECT * FROM AllergiesDetails
GO