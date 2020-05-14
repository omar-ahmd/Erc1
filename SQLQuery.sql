--hospital with section names
select [اسم المستشفى],[اسم القسم] 
from [أقسام المستشفيات] as kesem
join [المستشفيات مع اقسام] as hk
on kesem.[الرمز] = hk.[رمز القسم]
join [المستشفيات] as hospital
on hk.[رمز المشفى] = hospital.[رمز المستشفى]

--


select * from [المستشفيات]
select * from [أقسام المستشفيات]