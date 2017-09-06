-- =========== PENGISIAN LENGKAP SAMPAIL BORANG 8 =================== --
SELECT     SMMTemp.no_pendaftar,SMMTemp.pin, SMMTemp.nama, ukt_document.kk, ukt_document.ft_dpn_rumah, ukt_document.penghasilan, ukt_document.stnk, ukt_document.listrik, ukt_document.air, 
                      ukt_document.telp, ukt_ekonomi.nilai AS nilai_eko, ukt_falilitas.nilai AS nilai_fasilitas, ukt_harta.nilai AS nilai_harta, ukt_keluarga.nilai AS nilai_keluarga, ukt_lingkungan.nilai AS nilai_lingkungan, 
                      ukt_perabot.nilai AS nilai_perabot, ukt_pribadi.nilai AS nilai_pribadi, ukt_rumah.nilai AS nilai_rumah, SMMTemp.tahun, ukt_pribadi.nama, ukt_pribadi.gender, ukt_pribadi.prov, ukt_pribadi.kota, 
                      ukt_pribadi.kec, ukt_pribadi.email, ukt_pribadi.hp, ukt_pribadi.ayah, ukt_pribadi.pdayah, ukt_pribadi.ibu, ukt_pribadi.pdibu, ukt_keluarga.orgrumah, ukt_keluarga.sdr, 
                      ukt_keluarga.sdrkuliah, ukt_keluarga.sdrsekolah, ukt_rumah.stsrumah, ukt_rumah.smbrlistrik, ukt_rumah.dylistrik, ukt_rumah.bylistrik, ukt_rumah.sbair, ukt_rumah.byair, ukt_rumah.lstanah, 
                      ukt_rumah.lsbangunan, ukt_rumah.njop, ukt_rumah.atap, ukt_rumah.lantai, ukt_rumah.rgtenngah, ukt_rumah.dpr, ukt_rumah.cuci, ukt_rumah.mandi, ukt_rumah.teras, ukt_rumah.garasi, 
                      ukt_lingkungan.lstaman, ukt_lingkungan.pagar, ukt_perabot.hrmjtamu, ukt_perabot.hralmari, ukt_perabot.hrmjtengah, ukt_perabot.hrmjmakan, ukt_perabot.hrnjteras, ukt_perabot.hrtmtidur, 
                      ukt_perabot.hrtv, ukt_perabot.hrkomp, ukt_perabot.hrdapur, ukt_falilitas.bytelphp, ukt_falilitas.byint, ukt_ekonomi.pdptayah, ukt_ekonomi.pdptibu, ukt_ekonomi.htng, ukt_ekonomi.cicilan, 
                      ukt_harta.sawah, ukt_harta.tanah, ukt_harta.ternak, ukt_harta.mobil, ukt_harta.tabungan, ukt_harta.hiasan, ukt_harta.sepeda, 
                      ukt_ekonomi.nilai + ukt_falilitas.nilai + ukt_harta.nilai + ukt_keluarga.nilai + ukt_lingkungan.nilai + ukt_perabot.nilai + ukt_pribadi.nilai AS nilai_total, SMMTemp.bdk, SMMTemp.telp
FROM         SMMTemp INNER JOIN
                      ukt_document ON SMMTemp.no_pendaftar = ukt_document.no_daftar INNER JOIN
                      ukt_ekonomi ON SMMTemp.no_pendaftar = ukt_ekonomi.no_daftar INNER JOIN
                      ukt_falilitas ON SMMTemp.no_pendaftar = ukt_falilitas.no_daftar INNER JOIN
                      ukt_harta ON SMMTemp.no_pendaftar = ukt_harta.no_daftar INNER JOIN
                      ukt_lingkungan ON SMMTemp.no_pendaftar = ukt_lingkungan.no_daftar INNER JOIN
                      ukt_keluarga ON SMMTemp.no_pendaftar = ukt_keluarga.no_daftar INNER JOIN
                      ukt_perabot ON SMMTemp.no_pendaftar = ukt_perabot.no_daftar INNER JOIN
                      ukt_pribadi ON SMMTemp.no_pendaftar = ukt_pribadi.no_daftar INNER JOIN
                      ukt_rumah ON SMMTemp.no_pendaftar = ukt_rumah.no_daftar
WHERE     (SMMTemp.tahun = (select top 1 tahun from SMMTemp  group by tahun order by tahun desc))
ORDER BY nilai_total DESC


-- ---------- ULANGI SCRIPT INI KALAU ADA PENGISIAN DATA SOSIAL EKONOMI YANG MENYUSUL --------------
 -- ===============================1. MENENTUKAN UKT =============================== --
BEGIN TRAN

SELECT     SMMTemp.no_pendaftar, SMMTemp.tahun, 
                      ukt_ekonomi.nilai + ukt_falilitas.nilai + ukt_harta.nilai + ukt_keluarga.nilai + ukt_lingkungan.nilai + ukt_perabot.nilai + ukt_pribadi.nilai AS nilai_total, dbo.SMMTemp.bdk, dbo.SMMTemp.idprodi
into #TempTerimaSMUNTIDAR
FROM         SMMTemp INNER JOIN
                      ukt_document ON SMMTemp.no_pendaftar = ukt_document.no_daftar INNER JOIN
                      ukt_ekonomi ON SMMTemp.no_pendaftar = ukt_ekonomi.no_daftar INNER JOIN
                      ukt_falilitas ON SMMTemp.no_pendaftar = ukt_falilitas.no_daftar INNER JOIN
                      ukt_harta ON SMMTemp.no_pendaftar = ukt_harta.no_daftar INNER JOIN
                      ukt_lingkungan ON SMMTemp.no_pendaftar = ukt_lingkungan.no_daftar INNER JOIN
                      ukt_keluarga ON SMMTemp.no_pendaftar = ukt_keluarga.no_daftar INNER JOIN
                      ukt_perabot ON SMMTemp.no_pendaftar = ukt_perabot.no_daftar INNER JOIN
                      ukt_pribadi ON SMMTemp.no_pendaftar = ukt_pribadi.no_daftar INNER JOIN
                      ukt_rumah ON SMMTemp.no_pendaftar = ukt_rumah.no_daftar
WHERE     (SMMTemp.tahun = (select top 1 tahun from SMMTemp  group by tahun order by tahun desc)) AND ((SMMTemp.bdk IS NULL) OR (SMMTemp.bdk = 0) OR (SMMTemp.bdk = ''))
ORDER BY nilai_total DESC

DECLARE @NomorDaftarRingking VARCHAR(50) =''
DECLARE @KodeProdi varchar(50) = ''
DECLARE @ThnUkt varchar(20) = ''
declare @NilaiUkt int
declare @KatagoriUkt varchar(10)
declare @nomor_ukt bigint

WHILE(Exists(SELECT no_pendaftar from #TempTerimaSMUNTIDAR))
BEGIN	
	-- Select top 1 For Loop
	SELECT TOP 1 @NomorDaftarRingking=no_pendaftar, @KodeProdi = idprodi, @ThnUkt=tahun, @NilaiUkt = nilai_total FROM #TempTerimaSMUNTIDAR
	
	-- tahun ukt harus sama dengan tahun masuk !!!	
	SELECT @nomor_ukt=no, @KatagoriUkt=kategori FROM ukt_master WHERE idprodi=@KodeProdi AND thn_ukt=@ThnUkt AND nilai_bawah <= @NilaiUkt AND nilai_atas>=@NilaiUkt 
	
	-- Cek UKT --
	declare @GetUkt varchar(10) 
	select @GetUkt=ukt from SMMTemp where no_pendaftar=@NomorDaftarRingking
	IF (@GetUkt is NULL)
	BEGIN
		-- Update Ukt
		update SMMTemp set ukt = @KatagoriUkt where no_pendaftar=@NomorDaftarRingking	
	END
	
	-- move to the next loop
    DELETE FROM #TempTerimaSMUNTIDAR WHERE no_pendaftar = @NomorDaftarRingking
END

--select * from ##TempTerimaSMUNTIDAR
DROP TABLE #TempTerimaSMUNTIDAR

COMMIT TRAN
-- ==========================	END MENENTUKAN UKT				==================================

-- ========================== 2. POSTING TAGIHAN UKT SMUNTIDAR	==================================
BEGIN TRANSACTION
SELECT        SMMTemp.no_pendaftar, SMMTemp.nama, SMMTemp.tahun, SMMTemp.ukt, SMMTemp.idprodi, SMMTemp.terima, ukt_master.biaya, ukt_master.kategori
INTO #TempUktSMUNTIDAR
FROM          SMMTemp INNER JOIN
                         ukt_master ON SMMTemp.tahun = ukt_master.thn_ukt AND SMMTemp.ukt = ukt_master.kategori AND SMMTemp.idprodi = ukt_master.idprodi
WHERE        (SMMTemp.tahun = (select top 1 tahun from SMMTemp  group by tahun order by tahun desc))
GROUP BY SMMTemp.no_pendaftar, SMMTemp.nama, SMMTemp.tahun, SMMTemp.ukt, SMMTemp.idprodi, SMMTemp.terima, ukt_master.biaya, ukt_master.kategori

--SELECT * FROM #TempUktSMUNTIDAR

DECLARE @NoDaftarSMUNTIDAR VARCHAR(20)=''
WHILE(Exists(SELECT no_pendaftar from #TempUktSMUNTIDAR))
BEGIN
	--select top for loop
	SELECT TOP 1 @NoDaftarSMUNTIDAR=no_pendaftar FROM #TempUktSMUNTIDAR

	-- ======= Cek Udah Pernah Posting Atau Belum =======
	DECLARE	@NoUrutBill BIGINT
	SELECT @NoUrutBill=nomor FROM keu_posting_bank WHERE(keu_posting_bank.payeeId=@NoDaftarSMUNTIDAR)
	IF @@ROWCOUNT >= 1
	BEGIN
		DELETE FROM #TempUktSMUNTIDAR WHERE no_pendaftar = @NoDaftarSMUNTIDAR
		CONTINUE
		
		--RAISERROR('Posting Tagihan Ini Sudah Ada, Proses Dibatalkan  ',16,10)
		--RETURN;		
	END

		--==== Password ===== --
	DECLARE @PinBank VARCHAR(100) = ''
	DECLARE @newpwd VARCHAR(50)
	exec RandomPw @len=6, @min=65, @range=25, @exclude='O,Q,U,I,L', @output=@newpwd out
	select @PinBank=@newpwd
	PRINT @PinBank

	declare @nomor int
	declare @NewNomor varchar(50)
	declare @PreFix VARCHAR(10) = '07'
	
	-- ==== Create no billing ====
	SELECT @nomor = ISNULL(MAX(keu_posting_bank.nomor), 0) +1 from keu_posting_bank
	SELECT @NewNomor = @PreFix + RIGHT('00000000' + CAST(@nomor AS VARCHAR(8)),8)

	DECLARE @PesertaSMUNTIDAR VARCHAR(100) = ''
	DECLARE @ProdiSmUntidar VARCHAR(100) = ''
	DECLARE @TahunSmUntidar VARCHAR(20) = ''
	DECLARE @BiayaUKT DECIMAL

	SELECT @PesertaSMUNTIDAR=nama,@ProdiSmUntidar=terima,@TahunSmUntidar=tahun,@BiayaUKT=biaya FROM #TempUktSMUNTIDAR WHERE no_pendaftar = @NoDaftarSMUNTIDAR

	insert into keu_posting_bank (billingNo,payeeId,name,billRef1,billRef2,billRef3,billRef4,billRef5,amount_total,post_date,status,keterangan) values
	(@NewNomor,@NoDaftarSMUNTIDAR,@PesertaSMUNTIDAR,@ProdiSmUntidar,NULL,@TahunSmUntidar,@newpwd,'SM-UNTIDAR',@BiayaUKT,GETDATE(),'unpaid','REG-SMUNTIDAR')
	
	INSERT INTO bpd.dbo.keu_posting_bank
	        ( billingNo ,
	          payeeId ,
	          name ,
	          billRef1 ,
	          billRef2 ,
	          billRef3 ,
	          billRef4 ,
	          billRef5 ,
	          amount_total ,
	          post_date ,
	          status ,
	          keterangan
	        )
	VALUES  ( @NewNomor , -- billingNo - nvarchar(12)
	          @NoDaftarSMUNTIDAR , -- payeeId - nvarchar(10)
	          @PesertaSMUNTIDAR , -- name - nvarchar(45)
	          @ProdiSmUntidar , -- billRef1 - nvarchar(50)
	          NULL , -- billRef2 - nvarchar(25)
	          @TahunSmUntidar , -- billRef3 - nvarchar(25)
	          @newpwd,
	          'SM-UNTIDAR', -- billRef5 - nvarchar(10)
	          @BiayaUKT , -- amount_total - decimal
	          GETDATE() , -- post_date - datetime
	          'unpaid' , -- status - nvarchar(7)
	          'REG-SMUNTIDAR'  -- keterangan - varchar(50)
	        )

	-- move to the next loop
    	DELETE FROM #TempUktSMUNTIDAR WHERE no_pendaftar = @NoDaftarSMUNTIDAR
END
DROP TABLE #TempUktSMUNTIDAR

COMMIT TRANSACTION
-- ==========================	END POSTING TAGIHAN UKT SBMPTN	==================================
-- ---------- END ULANGI SCRIPT INI KALAU ADA PENGISIAN DATA SOSIAL EKONOMI YANG MENYUSUL --------------
