insert into tblProducts(Product_Name)
values ('Nail')

select * from tblProducts

update tblProducts
set SubCategory_ID = 1
where Product_Name = 'Nail'


update tblProducts
set Product_Image = 'None'
where Product_ID < 5