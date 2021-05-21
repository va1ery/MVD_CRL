CREATE TABLE ���������
(
  ���_��������� INT NOT NULL,
  ������������_��������� NVARCHAR(50),
  ����� INT,
  ����������� NVARCHAR(50),
  ���������� NVARCHAR(50),
  PRIMARY KEY (���_���������)
);

CREATE TABLE ������
(
  ���_������ INT NOT NULL,
  ������������ NVARCHAR(50),
  �������� INT,
  ����������� NVARCHAR(50),
  ���������� NVARCHAR(50),
  PRIMARY KEY (���_������)
);

CREATE TABLE ����_������������
(
  ���_����_������������ INT NOT NULL,
  ������������ NVARCHAR(50),
  ������ NVARCHAR(50),
  ��������� NVARCHAR(50),
  ���� INT,
  PRIMARY KEY (���_����_������������)
);

CREATE TABLE ������������
(
  ���_������������� INT NOT NULL,
  ��� NVARCHAR(50),
  ����_�������� DATE,
  ��� NVARCHAR(50),
  ����� NVARCHAR(50),
  PRIMARY KEY (���_�������������)
);

CREATE TABLE ����������
(
  ���_���������� INT NOT NULL,
  ��� NVARCHAR(50),
  ������� INT,
  ��� NVARCHAR(50),
  ����� NVARCHAR(50),
  ������� NVARCHAR(50),
  ����������_������ NVARCHAR(50),
  ���_��������� INT NOT NULL,
  ���_������ INT NOT NULL,
  PRIMARY KEY (���_����������),
  FOREIGN KEY (���_���������) REFERENCES ���������(���_���������),
  FOREIGN KEY (���_������) REFERENCES ������(���_������)
);

CREATE TABLE �����������
(
  �����_���� INT NOT NULL,
  ��� NVARCHAR(50),
  ����_�������� DATE,
  ��� NVARCHAR(50),
  ����� NVARCHAR(50),
  ��������� NVARCHAR(50),
  ���_���������� INT NOT NULL,
  ���_������������� INT NOT NULL,
  ���_����_������������ INT NOT NULL,
  PRIMARY KEY (�����_����),
  FOREIGN KEY (���_����������) REFERENCES ����������(���_����������),
  FOREIGN KEY (���_�������������) REFERENCES ������������(���_�������������),
  FOREIGN KEY (���_����_������������) REFERENCES ����_������������(���_����_������������)
);