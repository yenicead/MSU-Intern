using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace MSU_HR
{
    class Program
    {
        // Oracle bağlantısı için gerekli bilgiler.
        private static string host = "IP_Address";
        private static int port = 1521;
        private static string service_name = "service_name";
        private static string user = "user";
        private static string password = "password";

        // Oracle bağlantı katarı.
        private static string con_string = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                                            + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                                            + service_name + ")));Password=" + password + ";User ID=" + user;

        private static OracleConnection con_oracle = new OracleConnection();
        private static OracleCommand query_cursor = new OracleCommand();


        /* HR_EMPLOYEE */
        private static void insert_employee()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.insert_employee", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Manager Id : ");
            int manager_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Position : ");
            string position = Convert.ToString(Console.ReadLine());

            Console.Write("Identity No : ");
            int identity_no = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name : ");
            string name = Convert.ToString(Console.ReadLine());

            Console.Write("Surname : ");
            string surname = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Mail : ");
            string contact_mail = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Number : ");
            string contact_number = Convert.ToString(Console.ReadLine());
        
            query_cursor.Parameters.Add("pin_manager_id", OracleDbType.Int32).Value = manager_id;
            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;
            query_cursor.Parameters.Add("piv_position", OracleDbType.Varchar2).Value = position;
            query_cursor.Parameters.Add("pin_identity_no", OracleDbType.Int64).Value = identity_no;
            query_cursor.Parameters.Add("piv_name", OracleDbType.Varchar2).Value = name;
            query_cursor.Parameters.Add("piv_surname", OracleDbType.Varchar2).Value = surname;
            query_cursor.Parameters.Add("piv_contact_mail", OracleDbType.Varchar2).Value = contact_mail;
            query_cursor.Parameters.Add("piv_contact_number", OracleDbType.Varchar2).Value = contact_number;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Kayıt eklendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Kayıt eklenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }
                        
            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void delete_employee_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.delete_employee_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Employee Id : ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_employee_id", OracleDbType.Int32).Value = employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Kayıt silindi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Kayıt silinemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void delete_employee_by_identity_no()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.delete_employee_by_identity_no", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Identity No : ");
            int identity_no = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_identity_no", OracleDbType.Int32).Value = identity_no;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Kayıt silindi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Kayıt silinemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_department_to_employee()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_department_to_employee", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Employee Id : ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_employee_id", OracleDbType.Int32).Value = employee_id;
            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Çalışanın bölümü değiştirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Çalışanın bölümü değiştirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_manager_to_employee()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_manager_to_employee", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Employee Id : ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Manager Id : ");
            int manager_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_employee_id", OracleDbType.Int32).Value = employee_id;
            query_cursor.Parameters.Add("pin_manager_id", OracleDbType.Int32).Value = manager_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Çalışanın menajeri değiştirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Çalışanın menajeri değiştirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void get_employee_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.get_employee_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Employee Id : ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("employee_info", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;
            query_cursor.Parameters.Add("pin_employee_id", OracleDbType.Int32).Value = employee_id;
            

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                OracleDataReader refCursor_data = query_cursor.ExecuteReader();
                while (refCursor_data.Read())
                {
                    Console.WriteLine(refCursor_data.GetInt64(0) + " " + refCursor_data.GetInt64(1) + " " + refCursor_data.GetInt64(2) + " " + refCursor_data.GetString(3) + " " + refCursor_data.GetInt64(4) + " " + refCursor_data.GetString(5) + " " + refCursor_data.GetString(6) + " " + refCursor_data.GetString(7) + " " + refCursor_data.GetString(8));
                }
                refCursor_data.Close();
                Console.WriteLine("Çalışanın bilgileri getirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Çalışanın bilgileri getirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void get_employee_by_identity_no()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.get_employee_by_identity_no", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Employee Identity No : ");
            long identity_no = Convert.ToInt64(Console.ReadLine());

            query_cursor.Parameters.Add("employee_info", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;
            query_cursor.Parameters.Add("pin_identity_no", OracleDbType.Int64).Value = identity_no;


            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                OracleDataReader refCursor_data = query_cursor.ExecuteReader();
                while (refCursor_data.Read())
                {
                    Console.WriteLine(refCursor_data.GetInt64(0) + " " + refCursor_data.GetInt64(1) + " " + refCursor_data.GetInt64(2) + " " + refCursor_data.GetString(3) + " " + refCursor_data.GetInt64(4) + " " + refCursor_data.GetString(5) + " " + refCursor_data.GetString(6) + " " + refCursor_data.GetString(7) + " " + refCursor_data.GetString(8));
                }
                refCursor_data.Close();
                Console.WriteLine("Çalışanın bilgileri getirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Çalışanın bilgileri getirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void update_employee_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.update_employee_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Employee Id : ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Manager Id : ");
            int manager_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Position : ");
            string position = Convert.ToString(Console.ReadLine());

            Console.Write("Identity No : ");
            int identity_no = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name : ");
            string name = Convert.ToString(Console.ReadLine());

            Console.Write("Surname : ");
            string surname = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Mail : ");
            string contact_mail = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Number : ");
            string contact_number = Convert.ToString(Console.ReadLine());

            Console.Write("Hire Date : ");
            DateTime hire_date = Convert.ToDateTime(Console.ReadLine());

            query_cursor.Parameters.Add("pin_employee_id", OracleDbType.Int32).Value = employee_id;
            query_cursor.Parameters.Add("pin_manager_id", OracleDbType.Int32).Value = manager_id;
            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;
            query_cursor.Parameters.Add("piv_position", OracleDbType.Varchar2).Value = position;
            query_cursor.Parameters.Add("pin_identity_no", OracleDbType.Int64).Value = identity_no;
            query_cursor.Parameters.Add("piv_name", OracleDbType.Varchar2).Value = name;
            query_cursor.Parameters.Add("piv_surname", OracleDbType.Varchar2).Value = surname;
            query_cursor.Parameters.Add("piv_contact_mail", OracleDbType.Varchar2).Value = contact_mail;
            query_cursor.Parameters.Add("piv_contact_number", OracleDbType.Varchar2).Value = contact_number;
            query_cursor.Parameters.Add("pid_hire_date", OracleDbType.Date).Value = hire_date;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Kişi kaydı güncellendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Kişi kaydı güncellenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }


        /* HR_DEPARTMENT */
        private static void insert_department()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.insert_department", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Superior Department Id : ");
            int superior_department_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Manager Id : ");
            int manager_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Department Name : ");
            string department_name = Convert.ToString(Console.ReadLine());

            Console.Write("Agency Code : ");
            int agency_code = Convert.ToInt32(Console.ReadLine());

            Console.Write("Contact Mail : ");
            string contact_mail = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Number : ");
            string contact_number = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Employee Id : ");
            int contact_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_superior_department_id", OracleDbType.Int32).Value = superior_department_id;
            query_cursor.Parameters.Add("pin_manager_id", OracleDbType.Int32).Value = manager_id;
            query_cursor.Parameters.Add("piv_department_name", OracleDbType.Varchar2).Value = department_name;
            query_cursor.Parameters.Add("pin_agency_code", OracleDbType.Int32).Value = agency_code;
            query_cursor.Parameters.Add("piv_contact_mail", OracleDbType.Varchar2).Value = contact_mail;
            query_cursor.Parameters.Add("piv_contact_number", OracleDbType.Varchar2).Value = contact_number;
            query_cursor.Parameters.Add("pin_contact_employee_id", OracleDbType.Int32).Value = contact_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Bölüm kaydı eklendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Bölüm kaydı eklenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void delete_department_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.delete_department_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Bölüm kaydı silindi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Bölüm kaydı silinemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_manager_to_department()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_manager_to_department", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Manager Id : ");
            int manager_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;
            query_cursor.Parameters.Add("pin_manager_id", OracleDbType.Int32).Value = manager_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Bölümün menajeri değiştirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Bölümün menajeri değiştirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_employee_to_department()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_employee_to_department", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Contact Employee Id : ");
            int contact_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;
            query_cursor.Parameters.Add("pin_contact_employee_id", OracleDbType.Int32).Value = contact_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Bölümün çalışanı değiştirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Bölümün çalışanı değiştirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void get_department_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.get_department_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("department_info", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;
            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                OracleDataReader refCursor_data = query_cursor.ExecuteReader();
                while (refCursor_data.Read())
                {
                    Console.WriteLine(refCursor_data.GetInt64(0) + " " + refCursor_data.GetInt64(2) + " " 
                                    + refCursor_data.GetString(3) + " " + refCursor_data.GetInt64(4) + " " 
                                    + refCursor_data.GetString(5) + " " + refCursor_data.GetString(6) + " " + refCursor_data.GetInt64(7));
                }
                refCursor_data.Close();
                Console.WriteLine("Bölüm bilgileri getirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Bölüm bilgileri getirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void update_department_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.update_department_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Department Id : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Superior Department Id : ");
            int superior_department_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Manager Id : ");
            int manager_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Department Name : ");
            string department_name = Convert.ToString(Console.ReadLine());

            Console.Write("Agency Code : ");
            int agency_code = Convert.ToInt32(Console.ReadLine());

            Console.Write("Contact Mail : ");
            string contact_mail = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Number : ");
            string contact_number = Convert.ToString(Console.ReadLine());

            Console.Write("Contact Employee Id : ");
            int contact_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_department_id", OracleDbType.Int32).Value = department_id;
            query_cursor.Parameters.Add("pin_superior_department_id", OracleDbType.Int32).Value = superior_department_id;
            query_cursor.Parameters.Add("pin_manager_id", OracleDbType.Int32).Value = manager_id;
            query_cursor.Parameters.Add("piv_department_name", OracleDbType.Varchar2).Value = department_name;
            query_cursor.Parameters.Add("pin_agency_code", OracleDbType.Int32).Value = agency_code;
            query_cursor.Parameters.Add("piv_contact_mail", OracleDbType.Varchar2).Value = contact_mail;
            query_cursor.Parameters.Add("piv_contact_number", OracleDbType.Varchar2).Value = contact_number;
            query_cursor.Parameters.Add("pin_contact_employee_id", OracleDbType.Int32).Value = contact_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Bölüm kaydı güncellendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Bölüm kaydı güncellenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }


        /* HR_DOCUMENT */
        private static void insert_document()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.insert_document", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Type : ");
            int document_type = Convert.ToInt32(Console.ReadLine());

            Console.Write("Document File Name : ");
            string document_file_name = Convert.ToString(Console.ReadLine());

            Console.Write("Document Name : ");
            string document_name = Convert.ToString(Console.ReadLine());

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_document_type", OracleDbType.Int32).Value = document_type;
            query_cursor.Parameters.Add("piv_document_file_name", OracleDbType.Varchar2).Value = document_file_name;
            query_cursor.Parameters.Add("piv_document_name", OracleDbType.Varchar2).Value = document_name;
            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Doküman kaydı eklendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Doküman kaydı eklenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void delete_document_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.delete_document_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Id : ");
            int document_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_document_id", OracleDbType.Int32).Value = document_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Doküman kaydı silindi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Doküman kaydı silinemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_employee_to_document()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_employee_to_document", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Id : ");
            int document_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_document_id", OracleDbType.Int32).Value = document_id;
            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Dokümana ilgili çalışan atandı.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Dokümana ilgili çalışan atanamadı.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_type_to_document()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_type_to_document", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Id : ");
            int document_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Document Type : ");
            int document_type = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_document_id", OracleDbType.Int32).Value = document_id;
            query_cursor.Parameters.Add("pin_document_type", OracleDbType.Int32).Value = document_type;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Dokümanın tipi değiştirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Dokümanın tipi değiştirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void get_document_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.get_document_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Id : ");
            int document_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("document_info", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;
            query_cursor.Parameters.Add("pin_document_id", OracleDbType.Int32).Value = document_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                OracleDataReader refCursor_data = query_cursor.ExecuteReader();
                while (refCursor_data.Read())
                {
                    Console.WriteLine(refCursor_data.GetInt64(0) + " " + refCursor_data.GetInt32(1) + " " + refCursor_data.GetString(2) + " " + refCursor_data.GetString(4) + " " + refCursor_data.GetInt64(5));
                }
                refCursor_data.Close();
                Console.WriteLine("Doküman bilgileri getirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Doküman bilgileri getirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void update_document_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.update_document_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Id : ");
            int document_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Document Type : ");
            int document_type = Convert.ToInt32(Console.ReadLine());

            Console.Write("Document File Name : ");
            string document_file_name = Convert.ToString(Console.ReadLine());

            Console.Write("Document Content : ");
            string document_content = Convert.ToString(Console.ReadLine());

            Console.Write("Document Name : ");
            string document_name = Convert.ToString(Console.ReadLine());

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_document_id", OracleDbType.Int32).Value = document_id;
            query_cursor.Parameters.Add("pin_document_type", OracleDbType.Int32).Value = document_type;
            query_cursor.Parameters.Add("piv_document_file_name", OracleDbType.Varchar2).Value = document_file_name;
            query_cursor.Parameters.Add("pib_document_content", OracleDbType.Blob).Value = document_content;
            query_cursor.Parameters.Add("piv_document_name", OracleDbType.Varchar2).Value = document_name;
            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Doküman kaydı güncellendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Doküman kaydı güncellenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }


        /* HR_NOTES */
        private static void insert_note()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.insert_note", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Note Content : ");
            string note_content = Convert.ToString(Console.ReadLine());

            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;
            query_cursor.Parameters.Add("piv_note_content", OracleDbType.Varchar2).Value = note_content;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Not kaydı eklendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Not kaydı eklenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void delete_note_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.delete_note_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Note Id : ");
            int note_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_note_id", OracleDbType.Int32).Value = note_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Not kaydı silindi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Not kaydı silinemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_employee_to_note()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_employee_to_note", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Note Id : ");
            int note_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_note_id", OracleDbType.Int32).Value = note_id;
            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Not'a çalışanı değiştirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Not'a çalışanı değiştirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void get_note_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.get_note_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Note Id : ");
            int note_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("note_info", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;
            query_cursor.Parameters.Add("pin_note_id", OracleDbType.Int32).Value = note_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                OracleDataReader refCursor_data = query_cursor.ExecuteReader();
                while (refCursor_data.Read())
                {
                    Console.WriteLine(refCursor_data.GetInt64(0) + " " + refCursor_data.GetInt64(1) + " " + refCursor_data.GetString(2));
                }
                refCursor_data.Close();
                Console.WriteLine("Not bilgileri getirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Not bilgileri getirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void update_note_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.update_note_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Note Id : ");
            int note_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Note Content : ");
            string note_content = Convert.ToString(Console.ReadLine());

            query_cursor.Parameters.Add("pin_note_id", OracleDbType.Int32).Value = note_id;
            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;
            query_cursor.Parameters.Add("piv_note_content", OracleDbType.Varchar2).Value = note_content;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Not kaydı güncellendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Not kaydı güncellenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        
        /* HR_DOCUMENT_TYPE */
        private static void insert_document_type()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.insert_document_type", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Type Name : ");
            string document_type_name = Convert.ToString(Console.ReadLine());

            query_cursor.Parameters.Add("piv_document_type_name", OracleDbType.Varchar2).Value = document_type_name;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Doküman tipi eklendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Doküman tipi eklenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void get_document_type_by_type()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.get_document_type_by_type", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Type : ");
            int document_type = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("document_type_info", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;
            query_cursor.Parameters.Add("pin_document_type", OracleDbType.Int32).Value = document_type;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                OracleDataReader refCursor_data = query_cursor.ExecuteReader();
                while (refCursor_data.Read())
                {
                    Console.WriteLine(refCursor_data.GetInt64(0) + " " + refCursor_data.GetString(1));
                }
                refCursor_data.Close();
                Console.WriteLine("Doküman tipi bilgileri getirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Doküman tipi bilgileri getirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void update_document_type_by_type()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.update_document_type_by_type", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Document Type : ");
            int document_type = Convert.ToInt32(Console.ReadLine());

            Console.Write("Document Type Name : ");
            string document_type_name = Convert.ToString(Console.ReadLine());

            query_cursor.Parameters.Add("pin_document_type", OracleDbType.Int32).Value = document_type;
            query_cursor.Parameters.Add("piv_document_type_name", OracleDbType.Varchar2).Value = document_type_name;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Doküman tipi güncellendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Doküman tipi güncellenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        
        /* HR_ANNUAL_LEAVE */
        private static void insert_annual_leave()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.insert_annual_leave", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Begin Date : ");
            DateTime begin_date = Convert.ToDateTime(Console.ReadLine());

            Console.Write("End Date : ");
            DateTime end_date = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Number of Business Days : ");
            int number_of_business_days = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;
            query_cursor.Parameters.Add("pid_begin_date", OracleDbType.Date).Value = begin_date;
            query_cursor.Parameters.Add("pid_end_date", OracleDbType.Date).Value = end_date;
            query_cursor.Parameters.Add("pin_number_of_business_days", OracleDbType.Int32).Value = number_of_business_days;
            
            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Yıllık izin kaydı eklendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Yıllık izin kaydı eklenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void delete_annual_leave_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.delete_annual_leave_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Annual Leave Id : ");
            int annual_leave_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_annual_leave_id", OracleDbType.Int64).Value = annual_leave_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Yıllık izin kaydı silindi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Yıllık izin kaydı silinemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void assign_employee_to_annual()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.assign_employee_to_annual", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Annual Leave Id : ");
            int annual_leave_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_annual_leave_id", OracleDbType.Int64).Value = annual_leave_id;
            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int64).Value = related_employee_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Yıllık izine çalışan ataması yapıldı.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Yıllık izine çalışan ataması yapılamadı.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void get_annual_leave_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.get_annual_leave_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Annual Leave Id : ");
            long annual_leave_id = Convert.ToInt64(Console.ReadLine());

            query_cursor.Parameters.Add("annual_leave_info", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;
            query_cursor.Parameters.Add("pin_annual_leave_id", OracleDbType.Int64).Value = annual_leave_id;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                OracleDataReader refCursor_data = query_cursor.ExecuteReader();
                while (refCursor_data.Read())
                {
                    Console.WriteLine(refCursor_data.GetInt64(0) + " " + refCursor_data.GetInt32(1) + " " + refCursor_data.GetInt32(2) + " " + refCursor_data.GetInt32(3) + " " + refCursor_data.GetDateTime(4) + " " + refCursor_data.GetDateTime(5) + " " + refCursor_data.GetInt32(6));
                }
                refCursor_data.Close();
                Console.WriteLine("Yıllık izin bilgileri getirildi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Yıllık izin bilgileri getirilemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }

        private static void update_annual_leave_by_id()
        {
            con_oracle.ConnectionString = con_string;

            // Sorgu oluşturulup Oracle procedure ismi ve Oracle bağlantı adı parametre olarak girildi.
            query_cursor = new OracleCommand("MSU_HR.update_annual_leave_by_id", con_oracle);
            query_cursor.CommandType = CommandType.StoredProcedure;

            Console.Write("Annual Leave Id : ");
            long annual_leave_id = Convert.ToInt64(Console.ReadLine());

            Console.Write("Related Employee Id : ");
            int related_employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Approver Employee Id : ");
            int approver_employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Proxy Employee Id : ");
            int proxy_employee_id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Begin Date : ");
            DateTime begin_date = Convert.ToDateTime(Console.ReadLine());

            Console.Write("End Date : ");
            DateTime end_date = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Number of Business Days : ");
            int number_of_business_days = Convert.ToInt32(Console.ReadLine());

            query_cursor.Parameters.Add("pin_annual_leave_id", OracleDbType.Int64).Value = annual_leave_id;
            query_cursor.Parameters.Add("pin_related_employee_id", OracleDbType.Int32).Value = related_employee_id;
            query_cursor.Parameters.Add("pin_approver_employee_id", OracleDbType.Int32).Value = approver_employee_id;
            query_cursor.Parameters.Add("pin_proxy_employee_id", OracleDbType.Int32).Value = proxy_employee_id;
            query_cursor.Parameters.Add("pid_begin_date", OracleDbType.Date).Value = begin_date;
            query_cursor.Parameters.Add("pid_end_date", OracleDbType.Date).Value = end_date;
            query_cursor.Parameters.Add("pin_number_of_business_days", OracleDbType.Int32).Value = number_of_business_days;

            // Bağlantı durumunu kontrol ediyoruz.
            try
            {
                con_oracle.Open();
                query_cursor.ExecuteNonQuery();
                Console.WriteLine("Yıllık izin kaydı güncellendi.");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Yıllık izin kaydı güncellenemedi.");
                Console.WriteLine("## Hata : " + hata.Message);
            }

            // Oracle veritabanı bağlantısını sonlandırıyoruz.
            query_cursor.Dispose();
            con_oracle.Close();
        }


        static void Main(string[] args)
        {
            bool program_cont = true;
            int intTemp = 0;

            while (program_cont)
            {
                Console.WriteLine("\tHR_EMPLOYEE\n1. insert_employee\n2. delete_employee_by_id\n3. delete_employee_by_identity_no" +
                                  "\n4. assign_department_to_employee\n5. assign_manager_to_employee\n6. get_employee_by_id" +
                                  "\n7. get_employee_by_identity_no\n8. update_employee_by_id\n");

                Console.WriteLine("\tHR_DEPARTMENT\n9. insert_department\n10. delete_department_by_id\n11. assign_manager_to_department" +
                                   "\n12. assign_employee_to_department\n13. get_department_by_id\n14. update_department_by_id\n");

                Console.WriteLine("\tHR_DOCUMENT\n15. insert_document\n16. delete_document_by_id\n17. assign_employee_to_document" +
                                   "\n18. assign_type_to_document\n19. get_document_by_id\n20. update_document_by_id\n");

                Console.WriteLine("\tHR_NOTES\n21. insert_note\n22. delete_note_by_id\n23. assign_employee_to_note" +
                                   "\n24. get_note_by_id\n25. update_note_by_id\n");

                Console.WriteLine("\tHR_DOCUMENT_TYPE\n26. insert_document_type\n27. get_document_type_by_type\n28. update_document_type_by_type\n");

                Console.WriteLine("\tHR_ANNUAL_LEAVE\n29. insert_annual_leave\n30. delete_annual_leave_by_id\n31. assign_employee_to_annual" +
                                   "\n32. get_annual_leave_by_id\n33. update_annual_leave_by_id\n");

                Console.Write("Select an operation : ");
                intTemp = Convert.ToInt32(Console.ReadLine());

                switch (intTemp)
                {
                    case 1:
                        insert_employee();
                        break;
                    case 2:
                        delete_employee_by_id();
                        break;
                    case 3:
                        delete_employee_by_identity_no();
                        break;
                    case 4:
                        assign_department_to_employee();
                        break;
                    case 5:
                        assign_manager_to_employee();
                        break;
                    case 6:
                        get_employee_by_id();
                        break;
                    case 7:
                        get_employee_by_identity_no();
                        break;
                    case 8:
                        update_employee_by_id();
                        break;
                    case 9:
                        insert_department();
                        break;
                    case 10:
                        delete_department_by_id();
                        break;
                    case 11:
                        assign_manager_to_department();
                        break;
                    case 12:
                        assign_employee_to_department();
                        break;
                    case 13:
                        get_department_by_id();
                        break;
                    case 14:
                        update_department_by_id();
                        break;
                    case 15:
                        insert_document();
                        break;
                    case 16:
                        delete_document_by_id();
                        break;
                    case 17:
                        assign_employee_to_document();
                        break;
                    case 18:
                        assign_type_to_document();
                        break;
                    case 19:
                        get_document_by_id();
                        break;
                    case 20:
                        update_document_by_id();
                        break;
                    case 21:
                        insert_note();
                        break;
                    case 22:
                        delete_note_by_id();
                        break;
                    case 23:
                        assign_employee_to_note();
                        break;
                    case 24:
                        get_note_by_id();
                        break;
                    case 25:
                        update_note_by_id();
                        break;
                    case 26:
                        insert_document_type();
                        break;
                    case 27:
                        get_document_type_by_type();
                        break;
                    case 28:
                        update_document_type_by_type();
                        break;
                    case 29:
                        insert_annual_leave();
                        break;
                    case 30:
                        delete_annual_leave_by_id();
                        break;
                    case 31:
                        assign_employee_to_annual();
                        break;
                    case 32:
                        get_annual_leave_by_id();
                        break;
                    case 33:
                        update_annual_leave_by_id();
                        break;
                    default:
                        Console.WriteLine("Closing program.");
                        program_cont = false;
                       break;
                }   // Switch     
            }   // while
        }   // main 
    }   // program
}   // namespace
