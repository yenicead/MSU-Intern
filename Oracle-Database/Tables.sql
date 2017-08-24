--- hr_employee Table ---
CREATE TABLE hr_employee
    (
     employee_id Number(6) DEFAULT seq_employee_id_increment.NEXTVAL,
     manager_id Number(6),
     department_id Number(4) NOT NULL,
     position Varchar2(100), 
     identity_no Number(11),
     name Varchar2(100),
     surname Varchar2(50),
     contact_mail Varchar2(50),
     contact_number Varchar2(20),
     create_date Date DEFAULT SYSDATE,
     update_date Date,
     is_active NUMBER(1) DEFAULT 1, 
     
     CONSTRAINT pk_employee_id PRIMARY KEY (employee_id)
    );
     
CREATE SEQUENCE seq_employee_id_increment 
    START WITH 100001
    INCREMENT BY 1;

DROP TABLE hr_employee;
DROP SEQUENCE seq_employee_id_increment;

ALTER TABLE hr_employee
    ADD CONSTRAINT fk_department_id 
    FOREIGN KEY(department_id) 
    REFERENCES hr_department(department_id);
    
ALTER TABLE hr_employee
    ADD CONSTRAINT fk_emp_manager_id 
    FOREIGN KEY(manager_id) 
    REFERENCES hr_employee(employee_id);
    
AlTER TABLE hr_employee
    DROP CONSTRAINT fk_department_id;
    
AlTER TABLE hr_employee
    DROP CONSTRAINT fk_emp_manager_id;


--- hr_document Table ---
CREATE TABLE hr_document
    (
     document_id Number(10) DEFAULT seq_document_id_increment.NEXTVAL,
     document_type Number(4),
     document_file_name Varchar2(100),
     document_content Blob, 
     document_name Varchar2(100),
     related_employee_id Number(6),
     create_date Date DEFAULT SYSDATE,
     is_active NUMBER(1) DEFAULT 1,
     
     CONSTRAINT pk_document_id PRIMARY KEY (document_id)
    );
     
CREATE SEQUENCE seq_document_id_increment START WITH 1;

DROP TABLE hr_document;
DROP SEQUENCE seq_document_id_increment;

ALTER TABLE hr_document
    ADD CONSTRAINT fk_document_type 
    FOREIGN KEY(document_type) 
    REFERENCES hr_document_type(document_type);
    
ALTER TABLE hr_document
    ADD CONSTRAINT fk_related_employee_id 
    FOREIGN KEY(related_employee_id) 
    REFERENCES hr_employee(employee_id);


--- hr_document_type Table ---
CREATE TABLE hr_document_type
    (
     document_type Number(4) DEFAULT seq_document_type_increment.NEXTVAL,
     document_type_name Varchar2(100),
     
     CONSTRAINT pk_document_type PRIMARY KEY (document_type)
    );
     
CREATE SEQUENCE seq_document_type_increment START WITH 1;

DROP TABLE hr_document_type;
DROP SEQUENCE seq_document_type_increment;


--- hr_department Table ---
CREATE TABLE hr_department
    (
     department_id Number(4) DEFAULT seq_department_id_increment.NEXTVAL,
     superior_department_id Number(4),
     manager_id Number(6) NOT NULL, 
     department_name Varchar2(100),
     agency_code Number(7) NOT NULL,
     contact_mail Varchar2(50),
     contact_number Varchar2(20),
     contact_employee_id Number(6),
     create_date Date DEFAULT SYSDATE,
     update_date Date,
     is_active NUMBER(1) DEFAULT 1,
     
     CONSTRAINT pk_department_id PRIMARY KEY (department_id)
    );
     
CREATE SEQUENCE seq_department_id_increment 
    START WITH 1001 INCREMENT BY 1;

DROP TABLE hr_department;
DROP SEQUENCE seq_department_id_increment;   
    
ALTER TABLE hr_department
    ADD CONSTRAINT fk_contact_employee_id 
    FOREIGN KEY(contact_employee_id) 
    REFERENCES hr_employee(employee_id);
    
ALTER TABLE hr_department
    ADD CONSTRAINT fk_manager_id 
    FOREIGN KEY(manager_id) 
    REFERENCES hr_employee(employee_id);

    
AlTER TABLE hr_department
    DROP CONSTRAINT fk_contact_employee_id;
    
AlTER TABLE hr_department
    MODIFY agency_code NOT NULL;

--- hr_notes Table ---
CREATE TABLE hr_notes
    (
     note_id Number(10) DEFAULT seq_note_id_increment.NEXTVAL,
     related_employee_id Number(6),
     note_content Clob, 
     create_date Date DEFAULT SYSDATE,
     is_active NUMBER(1) DEFAULT 1,
     
     CONSTRAINT pk_note_id PRIMARY KEY (note_id)
    );
     
CREATE SEQUENCE seq_note_id_increment START WITH 1;

DROP TABLE hr_notes;
DROP SEQUENCE seq_note_id_increment;

ALTER TABLE hr_notes
    ADD CONSTRAINT fk_related_employee_id 
    FOREIGN KEY(related_employee_id) 
    REFERENCES hr_employee(employee_id);


--- hr_annual_leave Table ---
CREATE TABLE hr_annual_leave
    (
     annual_leave_id Number(10) DEFAULT seq_annual_leave_id_increment.NEXTVAL,
     related_employee_id Number(6) NOT NULL,
     approver_employee_id Number(6) NOT NULL, 
     proxy_employee_id Number(6),
     begin_date Date,
     end_date Date,
     number_of_business_days Number(4),
     create_date Date DEFAULT SYSDATE,
     update_date Date,
     is_active NUMBER(1) DEFAULT 1,
     
     CONSTRAINT pk_annual_leave_id PRIMARY KEY (annual_leave_id)
    );
     
CREATE SEQUENCE seq_annual_leave_id_increment START WITH 1;

DROP TABLE hr_annual_leave;
DROP SEQUENCE seq_annual_leave_id_increment;

ALTER TABLE hr_annual_leave
    ADD CONSTRAINT fk_related_employee_id 
    FOREIGN KEY(related_employee_id) 
    REFERENCES hr_employee(employee_id);


