        --- HR_EMPLOYEE--
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1009, 'IT', 11111111111, 'Adem', 'Yenice', 'deneme@gmail.com', '05555555555');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1009, 'IT', 22222222222, 'Kevin', 'Smith', 'k.smith@gmail.com', '0987654321');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1010, 'HR', 33333333333, 'Eva', 'Mtigh', 'e.mtigh@gmail.com', '6543214569');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1010, 'HR', 44444444444, 'David', 'Austin', 'd.austin@gmail.com', '701254654');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1011, 'Sales', 55555555555, 'Julia', 'Nayer', 'j.nayer@gmail.com', '951236547');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1012, 'Marketing', 666666666, 'James', 'Marlow', 'j.marlow@gmail.com', '1234567980');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1012, 'Marketing', 77777777777, 'Peter', 'Vargas', 'p.vargas@gmail.com', '5655214235');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1012, 'Marketing', 88888888888, 'Lisa', 'Ozer', 'l.ozer@gmail.com', '5554123325');
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(null, 1013, 'Administration', 99999999999, 'Eva', 'Mtigh', 'e.mtigh@gmail.com', '0147851365');
    
INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
    VALUES(100004, 1003, 'Belirsiz', 996452122, 'Adam', 'Smith', 'adam.smith@gmail.com', '789');
    
    
    
        --- HR_DEPARTMENT ---
INSERT INTO hr_department(superior_department_id, manager_id, department_name, agency_code, contact_mail, contact_number, contact_employee_id)
    VALUES(null, 100007, 'IT', 0214, 'IT@gmail.com', '555555', 100013);
INSERT INTO hr_department(superior_department_id, manager_id, department_name, agency_code, contact_mail, contact_number, contact_employee_id)
    VALUES(null, 100006, 'HR', 7125, 'HR@gmail.com', '77777', 100004);
INSERT INTO hr_department(superior_department_id, manager_id, department_name, agency_code, contact_mail, contact_number, contact_employee_id)
    VALUES(null, 100014, 'Sales', 1621, 'Sales@gmail.com', '88888', 100006);
INSERT INTO hr_department(superior_department_id, manager_id, department_name, agency_code, contact_mail, contact_number, contact_employee_id)
    VALUES(null, 100017, 'Marketing', 2555, 'marketing@gmail.com', '99999', 100007);
INSERT INTO hr_department(superior_department_id, manager_id, department_name, agency_code, contact_mail, contact_number, contact_employee_id)
    VALUES(null, 100013, 'Administration', 7895, 'administration@gmail.com', '99999', 100018);
INSERT INTO hr_department(superior_department_id, manager_id, department_name, agency_code, contact_mail, contact_number, contact_employee_id)
    VALUES(null, 100015, 'Law', 9654, 'deneme213@gmail.com', '65646', 100019);
    
    
    
        --- HR_DOCUMENT_TYPE ---
INSERT INTO hr_document_type(document_type_name)
    VALUES('PDF');
INSERT INTO hr_document_type(document_type_name)
    VALUES('DOC');
INSERT INTO hr_document_type(document_type_name)
    VALUES('DOCX');
INSERT INTO hr_document_type(document_type_name)
    VALUES('XLS');
INSERT INTO hr_document_type(document_type_name)
    VALUES('SQL');
INSERT INTO hr_document_type(document_type_name)
    VALUES('RAR');
    
    
    
        --- HR_DOCUMENT ---
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(1, 'deneme yazýsý', 'deneme yazim');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(2, 'merhaba dünya', 'html dosyasý');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(2, 'hello world', 'asdasd');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(3, 'maaþlar', '2017OcakMaaþlarý');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(4, 'müþteriler', 'yenileri');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(5, 'eski müþteriler', 'eskileri');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(6, 'gelenler', 'maliyet');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(6, 'gidenler', 'maaliyet');
INSERT INTO hr_document(document_type, document_file_name, document_name)
    VALUES(7, 'deneme yazýsý', 'deneme yazim');
        --- FK Güncellemesinden Sonra --- 
INSERT INTO hr_document(document_type, document_file_name, document_name, related_employee_id)
    VALUES(3, 'sonkez kayit', 'son123', 100015);
    
    
    
    --- HR_NOTES ---
INSERT INTO hr_notes(note_content)
    VALUES('deneme yazim');
INSERT INTO hr_notes(note_content)
    VALUES('asd123');
INSERT INTO hr_notes(note_content)
    VALUES('blok denemesi');
INSERT INTO hr_notes(note_content)
    VALUES('clob ne demek');
INSERT INTO hr_notes(note_content)
    VALUES('CLOB CLOB CLOB');
INSERT INTO hr_notes(note_content)
    VALUES('CILOP');
         --- FK Güncellemesinden Sonra --- 
INSERT INTO hr_notes(related_employee_id, note_content)
    VALUES(100004, 'deneme213213');
    
    
    
    --- HR_ANNUAL_LEAVE ---
INSERT INTO hr_annual_leave(begin_date, end_date, number_of_business_days)
    VALUES(TO_DATE('2003/05/03', 'yyyy/mm/dd'), TO_DATE('2003/07/03', 'yyyy/mm/dd'), 20);
INSERT INTO hr_annual_leave(begin_date, end_date, number_of_business_days)
    VALUES(TO_DATE('2005/05/03', 'yyyy/mm/dd'), TO_DATE('2005/05/21', 'yyyy/mm/dd'), 12);
INSERT INTO hr_annual_leave(begin_date, end_date, number_of_business_days)
    VALUES(TO_DATE('2008/11/05', 'yyyy/mm/dd'), TO_DATE('2008/11/15', 'yyyy/mm/dd'), 8);
INSERT INTO hr_annual_leave(begin_date, end_date, number_of_business_days)
    VALUES(TO_DATE('2011/09/10', 'yyyy/mm/dd'), TO_DATE('2011/09/23', 'yyyy/mm/dd'), 9);
        --- FK Güncellemesinden Sonra --- 
INSERT INTO hr_annual_leave(related_employee_id, begin_date, end_date, number_of_business_days)
    VALUES(100004, TO_DATE('2012/05/17', 'yyyy/mm/dd'), TO_DATE('2012/06/23', 'yyyy/mm/dd'), 30);      
    
    
COMMIT;
