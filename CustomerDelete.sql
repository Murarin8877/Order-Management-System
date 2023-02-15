SELECT          客戶.客戶編號, 訂貨主檔.訂單編號
FROM              客戶 INNER JOIN
                            訂貨主檔 ON 客戶.客戶編號 = 訂貨主檔.客戶編號 INNER JOIN
                            訂單明細 ON 訂貨主檔.訂單編號 = 訂單明細.訂單編號                           
WHERE          (客戶.客戶編號 = 'aaa')

SELECT 訂貨主檔.客戶編號,訂貨主檔.訂單編號 FROM 訂貨主檔 WHERE 訂貨主檔.客戶編號 = 'aaa'