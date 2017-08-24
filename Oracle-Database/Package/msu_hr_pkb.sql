CREATE OR REPLACE PACKAGE BODY MSU_HR AS
    --- HR_EMPLOYEE ---
    PROCEDURE insert_employee(pin_manager_id hr_employee.manager_id%type, pin_department_id HR_EMPLOYEE.department_id%type, 
                              piv_position HR_EMPLOYEE.position%type, pin_identity_no HR_EMPLOYEE.identity_no%type, piv_name HR_EMPLOYEE.name%type, 
                              piv_surname HR_EMPLOYEE.surname%type, piv_contact_mail HR_EMPLOYEE.contact_mail%type, piv_contact_number HR_EMPLOYEE.contact_number%type)
    IS BEGIN
        INSERT INTO hr_employee(manager_id, department_id, position, identity_no, name, surname, contact_mail, contact_number)
            VALUES(pin_manager_id, pin_department_id, piv_position, pin_identity_no, piv_name, piv_surname, piv_contact_mail, piv_contact_number);
        commit;
    END insert_employee;
    
    PROCEDURE delete_employee_by_id(pin_employee_id HR_EMPLOYEE.employee_id%type)
    IS BEGIN
        UPDATE hr_employee
            SET is_active = 0, update_date = SYSDATE
            WHERE employee_id = pin_employee_id;
        commit;
    END delete_employee_by_id;
    
    PROCEDURE delete_employee_by_identity_no(pin_identity_no HR_EMPLOYEE.identity_no%type)
    IS BEGIN
        UPDATE hr_employee
            SET is_active = 0, update_date = SYSDATE
            WHERE identity_no = pin_identity_no;
        commit;
    END delete_employee_by_identity_no;
    
    PROCEDURE assign_department_to_employee(pin_employee_id hr_employee.employee_id%type, pin_department_id HR_EMPLOYEE.department_id%type)
    IS BEGIN
        UPDATE hr_employee
            SET department_id = pin_department_id, update_date = SYSDATE
            WHERE employee_id = pin_employee_id;
        commit;
    END assign_department_to_employee;
    
    PROCEDURE assign_manager_to_employee(pin_employee_id hr_employee.employee_id%type, pin_manager_id HR_EMPLOYEE.manager_id%type)
    IS BEGIN
        UPDATE hr_employee
            SET manager_id = pin_manager_id, update_date = SYSDATE
            WHERE employee_id = pin_employee_id;
        commit;
    END assign_manager_to_employee;
    
    FUNCTION get_employee_by_id(pin_employee_id hr_employee.employee_id%type) RETURN SYS_REFCURSOR
    IS 
        employee_info SYS_REFCURSOR;
    BEGIN
        OPEN employee_info FOR
            SELECT * FROM HR_EMPLOYEE WHERE HR_EMPLOYEE.employee_id = pin_employee_id;
        RETURN employee_info;
    END get_employee_by_id;
    
    FUNCTION get_employee_by_identity_no(pin_identity_no hr_employee.identity_no%type) RETURN SYS_REFCURSOR
    IS 
        employee_info SYS_REFCURSOR;
    BEGIN
        OPEN employee_info FOR
            SELECT * FROM HR_EMPLOYEE WHERE HR_EMPLOYEE.identity_no = pin_identity_no;
        RETURN employee_info;
    END get_employee_by_identity_no;
    
    PROCEDURE update_employee_by_id(pin_employee_id hr_employee.employee_id%type, pin_manager_id hr_employee.manager_id%type, 
                                    pin_department_id HR_EMPLOYEE.department_id%type, piv_position HR_EMPLOYEE.position%type, 
                                    pin_identity_no HR_EMPLOYEE.identity_no%type, piv_name HR_EMPLOYEE.name%type, 
                                    piv_surname HR_EMPLOYEE.surname%type, piv_contact_mail HR_EMPLOYEE.contact_mail%type, 
                                    piv_contact_number HR_EMPLOYEE.contact_number%type, pid_hire_date HR_EMPLOYEE.hire_date%type)
    IS BEGIN
        UPDATE hr_employee
            SET manager_id = pin_manager_id, department_id = pin_department_id, position = piv_position,
                identity_no = pin_identity_no, name = piv_name, surname = piv_surname, contact_mail = piv_contact_mail,
                contact_number = piv_contact_number, hire_date = pid_hire_date, update_date = sysdate
            WHERE employee_id = pin_employee_id;
        commit;
    END update_employee_by_id;
    
    
     --- HR_DEPARTMENT ---
    PROCEDURE insert_department(pin_superior_department_id HR_DEPARTMENT.superior_department_id%type, pin_manager_id HR_DEPARTMENT.manager_id%type, piv_department_name HR_DEPARTMENT.department_name%type, pin_agency_code HR_DEPARTMENT.agency_code%type, piv_contact_mail HR_DEPARTMENT.contact_mail%type, piv_contact_number HR_DEPARTMENT.contact_number%type, pin_contact_employee_id HR_DEPARTMENT.contact_employee_id%type)
    IS BEGIN
        INSERT INTO hr_department(superior_department_id, manager_id, department_name, agency_code, contact_mail, contact_number, contact_employee_id)
            VALUES(pin_superior_department_id, pin_manager_id, piv_department_name, pin_agency_code, piv_contact_mail, piv_contact_number, pin_contact_employee_id);
        commit;
    END insert_department;
    
    PROCEDURE delete_department_by_id(pin_department_id HR_DEPARTMENT.department_id%type)
    IS BEGIN
        UPDATE hr_department
            SET is_active = 0, update_date = SYSDATE
            WHERE department_id = pin_department_id;
        commit;
    END delete_department_by_id;
    
    PROCEDURE assign_manager_to_department(pin_department_id hr_department.department_id%type, pin_manager_id hr_department.manager_id%type)
    IS BEGIN
        UPDATE hr_department
            SET manager_id = pin_manager_id, update_date = SYSDATE
            WHERE department_id = pin_department_id;
        commit;
    END assign_manager_to_department;
    
    PROCEDURE assign_employee_to_department(pin_department_id hr_department.department_id%type, pin_contact_employee_id hr_department.contact_employee_id%type)
    IS BEGIN
        UPDATE hr_department
            SET contact_employee_id = pin_contact_employee_id, update_date = SYSDATE
            WHERE department_id = pin_department_id;
        commit;
    END assign_employee_to_department;
    
    FUNCTION get_department_by_id(pin_department_id HR_DEPARTMENT.department_id%type) RETURN SYS_REFCURSOR
    IS 
        department_info SYS_REFCURSOR;
    BEGIN
        OPEN department_info FOR
            SELECT * FROM HR_DEPARTMENT WHERE HR_DEPARTMENT.department_id = pin_department_id;
        RETURN department_info;
    END get_department_by_id;
    
    PROCEDURE update_department_by_id(pin_department_id HR_DEPARTMENT.department_id%type, 
                                      pin_superior_department_id HR_DEPARTMENT.superior_department_id%type, 
                                      pin_manager_id HR_DEPARTMENT.manager_id%type, 
                                      piv_department_name HR_DEPARTMENT.department_name%type, 
                                      pin_agency_code HR_DEPARTMENT.agency_code%type, 
                                      piv_contact_mail HR_DEPARTMENT.contact_mail%type, 
                                      piv_contact_number HR_DEPARTMENT.contact_number%type, 
                                      pin_contact_employee_id HR_DEPARTMENT.contact_employee_id%type)
    IS BEGIN
        UPDATE HR_DEPARTMENT
            SET superior_department_id = pin_superior_department_id, manager_id = pin_manager_id, 
                department_name = piv_department_name, agency_code = pin_agency_code, contact_mail = piv_contact_mail, 
                contact_number = piv_contact_number, contact_employee_id = pin_contact_employee_id, update_date = sysdate
            WHERE department_id = pin_department_id;
        commit;
    END update_department_by_id;
    
    
    --- HR_DOCUMENT_TYPE ---
    PROCEDURE insert_document_type(piv_document_type_name HR_DOCUMENT_TYPE.DOCUMENT_TYPE_NAME%TYPE)
    IS BEGIN
        INSERT INTO hr_document_type(document_type_name)
            VALUES(piv_document_type_name);
        commit;
    END insert_document_type;
    
    FUNCTION get_document_type_by_type(pin_document_type HR_DOCUMENT_TYPE.document_type%TYPE) RETURN SYS_REFCURSOR
    IS 
        document_type_info SYS_REFCURSOR;
    BEGIN
        OPEN document_type_info FOR
            SELECT * FROM HR_DOCUMENT_TYPE WHERE HR_DOCUMENT_TYPE.document_type = pin_document_type;
        RETURN document_type_info;
    END get_document_type_by_type;
    
    PROCEDURE update_document_type_by_type(pin_document_type HR_DOCUMENT_TYPE.document_type%TYPE, piv_document_type_name HR_DOCUMENT_TYPE.DOCUMENT_TYPE_NAME%TYPE)
    IS BEGIN
        UPDATE HR_DOCUMENT_TYPE
            SET DOCUMENT_TYPE_NAME = piv_document_type_name
            WHERE document_type = pin_document_type;
        commit;
    END update_document_type_by_type;
    
    
    --- HR_DOCUMENT ---
    PROCEDURE insert_document(pin_document_type hr_document.document_type%type, piv_document_file_name hr_document.document_file_name%type, piv_document_name hr_document.document_name%type, pin_related_employee_id hr_document.related_employee_id%type)
    IS BEGIN
        INSERT INTO hr_document(document_type, document_file_name, document_name, related_employee_id)
            VALUES(pin_document_type, piv_document_file_name, piv_document_name, pin_related_employee_id);
        commit;
    END insert_document;
    
    PROCEDURE delete_document_by_id(pin_document_id hr_document.document_id%type)
    IS BEGIN
        UPDATE hr_document
            SET is_active = 0
            WHERE document_id = pin_document_id;
        commit;
    END delete_document_by_id;
    
    PROCEDURE assign_employee_to_document(pin_document_id hr_document.document_id%type, pin_related_employee_id hr_document.related_employee_id%type)
    IS BEGIN
        UPDATE hr_document
            SET related_employee_id = pin_related_employee_id
            WHERE document_id = pin_document_id;
        commit;
    END assign_employee_to_document;
    
    PROCEDURE assign_type_to_document(pin_document_id hr_document.document_id%type, pin_document_type hr_document.document_type%type)
    IS BEGIN
        UPDATE hr_document
            SET document_type = pin_document_type
            WHERE document_id = pin_document_id;
        commit;
    END assign_type_to_document;
    
    FUNCTION get_document_by_id(pin_document_id HR_DOCUMENT.document_id%TYPE) RETURN SYS_REFCURSOR
    IS 
        document_info SYS_REFCURSOR;
    BEGIN
        OPEN document_info FOR
            SELECT * FROM HR_DOCUMENT WHERE HR_DOCUMENT.document_id = pin_document_id;
        RETURN document_info;
    END get_document_by_id;
    
    PROCEDURE update_document_by_id(pin_document_id hr_document.document_id%type, pin_document_type hr_document.document_type%type, 
                                    piv_document_file_name hr_document.document_file_name%type,
                                    pib_document_content hr_document.document_content%type,
                                    piv_document_name hr_document.document_name%type, 
                                    pin_related_employee_id hr_document.related_employee_id%type)
    IS BEGIN
        UPDATE hr_document
            SET document_type = pin_document_type, document_file_name = piv_document_file_name, document_content = pib_document_content, 
                document_name = piv_document_name, related_employee_id = pin_related_employee_id
            WHERE document_id = pin_document_id;
        commit;
    END update_document_by_id;
    
    
    --- HR_NOTES ---
    PROCEDURE insert_note(pin_related_employee_id hr_notes.related_employee_id%type, piv_note_content hr_notes.note_content%type)
    IS BEGIN
        INSERT INTO hr_notes(related_employee_id, note_content)
            VALUES(pin_related_employee_id, piv_note_content);
        commit;
    END insert_note;
    
    PROCEDURE delete_note_by_id(pin_note_id hr_notes.note_id%type)
    IS BEGIN
        UPDATE hr_notes
            SET is_active = 0
            WHERE note_id = pin_note_id;
        commit;
    END delete_note_by_id;
    
    PROCEDURE assign_employee_to_note(pin_note_id hr_notes.note_id%type, pin_related_employee_id hr_notes.related_employee_id%type)
    IS BEGIN
        UPDATE hr_notes
            SET related_employee_id = pin_related_employee_id
            WHERE note_id = pin_note_id;
        commit;
    END assign_employee_to_note;
    
    FUNCTION get_note_by_id(pin_note_id HR_NOTES.note_id%TYPE) RETURN SYS_REFCURSOR
    IS 
        note_info SYS_REFCURSOR;
    BEGIN
        OPEN note_info FOR
            SELECT * FROM HR_NOTES WHERE HR_NOTES.note_id = pin_note_id;
        RETURN note_info;
    END get_note_by_id;
    
    PROCEDURE update_note_by_id(pin_note_id hr_notes.note_id%type, pin_related_employee_id hr_notes.related_employee_id%type, piv_note_content hr_notes.note_content%type)
    IS BEGIN
        UPDATE hr_notes
            SET related_employee_id = pin_related_employee_id, note_content = piv_note_content
            WHERE note_id = pin_note_id;
        commit;
    END update_note_by_id;
    
    
    --- HR_ANNUAL_LEAVE ---
    PROCEDURE insert_annual_leave(pin_related_employee_id hr_annual_leave.related_employee_id%type, pid_begin_date hr_annual_leave.begin_date%type, pid_end_date hr_annual_leave.end_date%type, pin_number_of_business_days hr_annual_leave.number_of_business_days%type)
    IS BEGIN
        INSERT INTO hr_annual_leave(related_employee_id, begin_date, end_date, number_of_business_days)
            VALUES(pin_related_employee_id, pid_begin_date, pid_end_date, pin_number_of_business_days);
        commit;
    END insert_annual_leave;
    
    PROCEDURE delete_annual_leave_by_id(pin_annual_leave_id hr_annual_leave.annual_leave_id%type)
    IS BEGIN
        UPDATE hr_annual_leave
            SET is_active = 0, update_date = SYSDATE
            WHERE annual_leave_id = pin_annual_leave_id;
        commit;
    END delete_annual_leave_by_id;
    
    PROCEDURE assign_employee_to_annual(pin_annual_leave_id hr_annual_leave.annual_leave_id%type, pin_related_employee_id hr_annual_leave.related_employee_id%type)
    IS BEGIN
        UPDATE hr_annual_leave
            SET related_employee_id = pin_related_employee_id, update_date = SYSDATE
            WHERE annual_leave_id = pin_annual_leave_id;
        commit;
    END assign_employee_to_annual;
    
    FUNCTION get_annual_leave_by_id(pin_annual_leave_id HR_ANNUAL_LEAVE.annual_leave_id%TYPE) RETURN SYS_REFCURSOR
    IS 
        annual_leave_info SYS_REFCURSOR;
    BEGIN
        OPEN annual_leave_info FOR
            SELECT * FROM HR_ANNUAL_LEAVE WHERE HR_ANNUAL_LEAVE.annual_leave_id = pin_annual_leave_id;
        RETURN annual_leave_info;
    END get_annual_leave_by_id;
    
    PROCEDURE update_annual_leave_by_id(pin_annual_leave_id hr_annual_leave.annual_leave_id%type, 
                                        pin_related_employee_id hr_annual_leave.related_employee_id%type,
                                        pin_approver_employee_id hr_annual_leave.approver_employee_id%type,
                                        pin_proxy_employee_id hr_annual_leave.proxy_employee_id%type,
                                        pid_begin_date hr_annual_leave.begin_date%type, 
                                        pid_end_date hr_annual_leave.end_date%type, 
                                        pin_number_of_business_days hr_annual_leave.number_of_business_days%type)
    IS BEGIN
         UPDATE hr_annual_leave
            SET related_employee_id = pin_related_employee_id, approver_employee_id = pin_approver_employee_id,
                proxy_employee_id = pin_proxy_employee_id, begin_date = pid_begin_date, end_date = pid_end_date,
                number_of_business_days = pin_number_of_business_days, update_date = sysdate
            WHERE annual_leave_id = pin_annual_leave_id;
        commit;
    END update_annual_leave_by_id;
END MSU_HR;