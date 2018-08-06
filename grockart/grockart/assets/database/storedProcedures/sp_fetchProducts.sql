drop procedure if exists sp_fetchProducts;
delimiter #
CREATE PROCEDURE sp_fetchProducts()
	
BEGIN
select 
	categoryName,
    productName,
    quantityperunit, 
    productImage, 
    price, 
    (
		SELECT storeLogo 
        FROM tbl_store 
        INNER JOIN tbl_productByStore 
        ON tbl_store.sid = tbl_productByStore.sid 
        WHERE pid = a.pid 
        AND cid = a.cid 
        AND price = a.price LIMIT 1
	) 'storeLogo' ,
    quantity
FROM(
	SELECT 
	categoryName,
	productName,    
	quantityperunit,
	min(price) 'Price',
	productImage,
	quantity,
    pbs.pid,
    pbs.cid
	FROM 
		tbl_productByStore pbs
	INNER JOIN 
		tbl_category c
	ON pbs.cID = c.cID
	INNER JOIN 
		tbl_product p
	ON pbs.pID = p.pID
	group by categoryname, productname
) a;    
END#
