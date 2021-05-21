CREATE TABLE Должности
(
  Код_должности INT NOT NULL,
  Наименование_должности NVARCHAR(50),
  Оклад INT,
  Обязанности NVARCHAR(50),
  Требования NVARCHAR(50),
  PRIMARY KEY (Код_должности)
);

CREATE TABLE Звания
(
  Код_звания INT NOT NULL,
  Наименование NVARCHAR(50),
  Надбавка INT,
  Обязанности NVARCHAR(50),
  Требования NVARCHAR(50),
  PRIMARY KEY (Код_звания)
);

CREATE TABLE Виды_преступлений
(
  Код_вида_преступления INT NOT NULL,
  Наименование NVARCHAR(50),
  Статья NVARCHAR(50),
  Наказание NVARCHAR(50),
  Срок INT,
  PRIMARY KEY (Код_вида_преступления)
);

CREATE TABLE Пострадавшие
(
  Код_пострадавшего INT NOT NULL,
  ФИО NVARCHAR(50),
  Дата_рождения DATE,
  Пол NVARCHAR(50),
  Адрес NVARCHAR(50),
  PRIMARY KEY (Код_пострадавшего)
);

CREATE TABLE Сотрудники
(
  Код_сотрудника INT NOT NULL,
  ФИО NVARCHAR(50),
  Возраст INT,
  Пол NVARCHAR(50),
  Адрес NVARCHAR(50),
  Телефон NVARCHAR(50),
  Паспортные_данные NVARCHAR(50),
  Код_должности INT NOT NULL,
  Код_звания INT NOT NULL,
  PRIMARY KEY (Код_сотрудника),
  FOREIGN KEY (Код_должности) REFERENCES Должности(Код_должности),
  FOREIGN KEY (Код_звания) REFERENCES Звания(Код_звания)
);

CREATE TABLE Преступники
(
  Номер_дела INT NOT NULL,
  ФИО NVARCHAR(50),
  Дата_рождения DATE,
  Пол NVARCHAR(50),
  Адрес NVARCHAR(50),
  Состояние NVARCHAR(50),
  Код_сотрудника INT NOT NULL,
  Код_пострадавшего INT NOT NULL,
  Код_вида_преступления INT NOT NULL,
  PRIMARY KEY (Номер_дела),
  FOREIGN KEY (Код_сотрудника) REFERENCES Сотрудники(Код_сотрудника),
  FOREIGN KEY (Код_пострадавшего) REFERENCES Пострадавшие(Код_пострадавшего),
  FOREIGN KEY (Код_вида_преступления) REFERENCES Виды_преступлений(Код_вида_преступления)
);