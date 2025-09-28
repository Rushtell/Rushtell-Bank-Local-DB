SELECT * FROM Workers


SELECT * FROM VIPworkers


SELECT * FROM Organizations


SELECT name, salary,
methodPayments, mounthCreateStandartPaymentMeth, 
deposit, depositType, type FROM Organizations WHERE Id = 1


UPDATE Workers SET Workers.deposit = 100.523324
WHERE Id = 0



SELECT MAX (Id) FROM Workers

SELECT Workers.age FROM Workers, Organizations Where Id = 5

SELECT Id FROM Workers WHERE Id = 50

DELETE FROM Workers WHERE Id >= 0
DELETE FROM VIPworkers WHERE Id >= 0
DELETE FROM Organizations WHERE Id >= 0

INSERT INTO Workers ([Id], [firstname],[lastname],
[age], [salary], [deposit], [methodPayments], 
[mounthCreateStandartPaymentMeth], [depositType], [type])
VALUES
(0, '0','0', 0, 0 ,0 ,0 ,0 ,'0' ,'0')

INSERT INTO VIPworkers ([Id], [firstname],[lastname],
[age], [salary], [deposit], [methodPayments], 
[mounthCreateStandartPaymentMeth], [depositType], [type])
VALUES
(1, '0','0', 0, 0 ,0 ,0 ,0 ,'0' ,'0')

INSERT INTO Organizations ([Id], [name], [salary], [deposit], [methodPayments], 
[mounthCreateStandartPaymentMeth], [depositType], [type])
VALUES
(2, '0', 0 ,0 ,0 ,0 ,'0' ,'0')


CREATE TABLE [dbo].[Workers] (
    [Id]                              INT           NOT NULL,
    [firstname]                       NVARCHAR (50) NOT NULL,
    [lastname]                        NVARCHAR (50) NOT NULL,
    [age]                             INT           NOT NULL,
    [salary]                          INT           NOT NULL,
    [deposit]                         FLOAT    NOT NULL,
    [methodPayments]                  INT           NOT NULL,
    [mounthCreateStandartPaymentMeth] INT           NOT NULL,
    [depositType]                     NVARCHAR (50) NOT NULL,
    [type]                            NVARCHAR (50) NOT NULL
);






