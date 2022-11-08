Imports System.Console
Imports System.IO
Module Module1
    Dim jabatan As String
    Dim statusPegawai As String
    Dim gajiGol As Integer
    Dim tunjIstri As Integer
    Dim tunjAnak As Integer
    Dim gajiBruto As Integer
    Dim koperasi As Integer
    Dim biayaJabatan As Integer
    Dim danaPensiun As Integer
    Dim gajiNetto As Integer
    Dim nama As String
    Dim golongan As Integer
    Dim jenKel As String
    Dim kawin As String
    Dim jmlAnak As Integer
    Dim gajiPokok As Integer

    Sub Main()

        WriteLine("----------------------------")
        Write(" SLIP GAJI : ")
        nama = ReadLine()
        WriteLine("----------------------------")
        WriteLine()

        Dim ulang1 As Boolean
        ulang1 = True

        Do While ulang1 = True
            Try
                Write("Golongan :  ")
                golongan = ReadLine()

                If golongan > 3 Or golongan < 1 Then
                    WriteLine()
                    WriteLine("Golongan salah")
                Else
                    ulang1 = False
                End If
            Catch ex As InvalidCastException
                WriteLine("Ulangi mengisi golongan")
            End Try

        Loop

        Dim ulang2 As Boolean
        ulang2 = True

        Do While ulang2 = True
            Try
                WriteLine()
                Write("Jabatan : ")
                jabatan = UCase(ReadLine())

                If jabatan <> "KEPALA" And jabatan <> "MANAGER" And jabatan <> "UMUM" Then
                    WriteLine()
                    WriteLine("Jabatan salah")
                Else
                    ulang2 = False
                End If
            Catch ex As InvalidCastException
                WriteLine("Ulangi mengisi jabatan")
            End Try

        Loop

        Dim ulang3 As Boolean
        ulang3 = True

        Do While ulang3 = True
            Try
                WriteLine()
                Write("Status Kepegawaian : ")
                statusPegawai = UCase(ReadLine())

                If statusPegawai <> "TETAP" And statusPegawai <> "HONORER" Then
                    WriteLine()
                    WriteLine("Salah")
                Else
                    ulang3 = False
                End If
            Catch ex As InvalidCastException
                WriteLine("Ulangi mengisi status kepegawaian")
            End Try

        Loop

        Dim ulang4 As Boolean
        ulang4 = True

        Do While ulang4 = True
            Try
                WriteLine()
                Write("Jenis Kelamin P/L : ")
                jenKel = UCase(ReadLine())

                If jenKel <> "P" And jenKel <> "L" Then
                    WriteLine()
                    WriteLine(" Salah")
                Else
                    ulang4 = False
                End If
            Catch ex As InvalidCastException
                WriteLine("Ulangi mengisi jenis kelamin")
            End Try

        Loop

        Dim ulang5 As Boolean
        ulang5 = True

        Do While ulang5 = True
            Try
                WriteLine()
                Write("Status Kawin : ")
                kawin = UCase(ReadLine())

                jmlAnak = 0
                If kawin = "KAWIN" Then
                    Write(" jumlah anak : ")
                    jmlAnak = jmlAnak + ReadLine()

                    WriteLine("Status kawin anda : " & kawin)
                    WriteLine("Jumlah anak anda : " & jmlAnak)
                    ulang5 = False
                ElseIf kawin = "BELUM" Then
                    WriteLine("Status kawin anda : " & kawin)
                    ulang5 = False
                Else
                    WriteLine()
                    WriteLine("Error")
                End If
            Catch ex As InvalidCastException
                WriteLine("Ulangi mengisi status kawin")
            End Try

        Loop

        Process()
        Output()

        
    End Sub

    Sub Process()
        If golongan = 1 Then
            gajiGol = 1500000
        ElseIf golongan = 2 Then
            gajiGol = 2500000
        ElseIf golongan = 3 Then
            gajiGol = 3500000
        End If
        gajiPokok = gajiGol

        tunjIstri = 0
        If jenKel = "L" And kawin = "KAWIN" Then
            If golongan = 1 Then
                tunjIstri = 0.01 * gajiPokok
            ElseIf golongan = 2 Then
                tunjIstri = 0.03 * gajiPokok
            ElseIf golongan = 3 Then
                tunjIstri = 0.05 * gajiPokok
            End If
        End If

        If kawin = "KAWIN" And jmlAnak > 0 Then
            tunjAnak = 0.01 * gajiPokok
            If jmlAnak <= 2 Then
                tunjAnak = tunjAnak * jmlAnak
            Else
                tunjAnak = tunjAnak * 2
            End If
        End If

        gajiBruto = gajiPokok + tunjAnak + tunjIstri

        If statusPegawai = "TETAP" Then
            koperasi = 5000
        Else
            koperasi = 0
        End If

        If jabatan = "KEPALA" Then
            biayaJabatan = biayaJabatan + (0.005 * gajiPokok)
        ElseIf jabatan = "MANAGER" Then
            biayaJabatan = biayaJabatan + (0.003 * gajiPokok)
        End If

        If jabatan = "KEPALA" And statusPegawai = "TETAP" Then
            danaPensiun = danaPensiun + (0.005 * gajiPokok)
        ElseIf jabatan = "MANAGER" And statusPegawai = "TETAP" Then
            danaPensiun = danaPensiun + (0.003 * gajiPokok)
        End If

        gajiNetto = gajiBruto - (koperasi + biayaJabatan + danaPensiun)
    End Sub

    Sub Output()
        Clear()
        WriteLine()
        WriteLine("----------------------------")
        WriteLine("     SLIP GAJI: " & nama)
        WriteLine("----------------------------")
        WriteLine("1. Golongan          : " & golongan)
        WriteLine("2. Jabatan           : " & jabatan)
        WriteLine("3. Status Pegawai    : " & statusPegawai)
        WriteLine("4. Jenis Kelamin     : " & jenKel)
        WriteLine("5. Status Kawin      : " & kawin)
        WriteLine("6. Jumlah Anak       : " & jmlAnak)
        WriteLine("7. Gaji Pokok        : Rp  " & FormatNumber(Convert.ToInt32(gajiPokok)), 0, TriState.True, 0)
        WriteLine("8. Tunjangan Istri   : Rp  " & FormatNumber(Convert.ToInt32(tunjIstri)), 0, TriState.True, 0)
        WriteLine("9. Tunjangan Anak    : Rp  " & FormatNumber(Convert.ToInt32(tunjAnak)), 0, TriState.True, 0)
        WriteLine("        Gaji Bruto   : Rp  " & FormatNumber(Convert.ToInt32(gajiBruto)), 0, TriState.True, 0)
        WriteLine("10. Potongan Koperasi: Rp  " & FormatNumber(Convert.ToInt32(koperasi)), 0, TriState.True, 0)
        WriteLine("11. Biaya Jabatan    : Rp  " & FormatNumber(Convert.ToInt32(biayaJabatan)), 0, TriState.True, 0)
        WriteLine("12. Dana Pensiun     : Rp  " & FormatNumber(Convert.ToInt32(danaPensiun)), 0, TriState.True, 0)
        WriteLine("        Gaji Netto   : Rp  " & FormatNumber(Convert.ToInt32(gajiNetto)), 0, TriState.True, 0)
        WriteLine("----------------------------")
        WriteLine()

        Dim mydate As String = DateTime.Now.ToString("dd'-'MM'-'yyyy-HH-mm-ss")
        Dim filename As String

        filename = "Slip Gaji " & nama & " " & mydate & ".txt"

        Dim myWriter As StreamWriter

        myWriter = My.Computer.FileSystem.OpenTextFileWriter("D:\" & filename, True)

        myWriter.WriteLine("----------------------------")
        myWriter.WriteLine("     SLIP GAJI: " & nama)
        myWriter.WriteLine("----------------------------")
        myWriter.WriteLine("1. Golongan          : " & golongan)
        myWriter.WriteLine("2. Jabatan           : " & jabatan)
        myWriter.WriteLine("3. Status Pegawai    : " & statusPegawai)
        myWriter.WriteLine("4. Jenis Kelamin     : " & jenKel)
        myWriter.WriteLine("5. Status Kawin      : " & kawin)
        myWriter.WriteLine("6. Jumlah Anak       : " & jmlAnak)
        myWriter.WriteLine("7. Gaji Pokok        : Rp " & FormatNumber(Convert.ToInt32(gajiPokok)), 0, TriState.True, 0)
        myWriter.WriteLine("8. Tunjangan Istri   : Rp  " & FormatNumber(Convert.ToInt32(tunjIstri)), 0, TriState.True, 0)
        myWriter.WriteLine("9. Tunjangan Anak    : Rp  " & FormatNumber(Convert.ToInt32(tunjAnak)), 0, TriState.True, 0)
        myWriter.WriteLine("        Gaji Bruto   : Rp  " & FormatNumber(Convert.ToInt32(gajiBruto)), 0, TriState.True, 0)
        myWriter.WriteLine("10. Potongan Koperasi: Rp  " & FormatNumber(Convert.ToInt32(koperasi)), 0, TriState.True, 0)
        myWriter.WriteLine("11. Biaya Jabatan    : Rp  " & FormatNumber(Convert.ToInt32(biayaJabatan)), 0, TriState.True, 0)
        myWriter.WriteLine("12. Dana Pensiun     : Rp  " & FormatNumber(Convert.ToInt32(danaPensiun)), 0, TriState.True, 0)
        myWriter.WriteLine("        Gaji Netto   : Rp  " & FormatNumber(Convert.ToInt32(gajiNetto)), 0, TriState.True, 0)
        myWriter.WriteLine("----------------------------")
        myWriter.WriteLine("Tanggal : " & mydate)
        myWriter.WriteLine()
        myWriter.Close()
    End Sub

End Module