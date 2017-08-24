CREATE OR REPLACE PACKAGE MSU_HR AS 
    --- HR_EMPLOYEE ---
    PROCEDURE insert_employee(pin_manager_id hr_employee.manager_id%type, pin_department_id HR_EMPLOYEE.department_id%type, 
                              piv_position HR_EMPLOYEE.position%type, pin_identity_no HR_EMPLOYEE.identity_no%type, 
                              piv_name HR_EMPLOYEE.name%type, 
                              piv_surname HR_EMPLOYEE.surname%type, piv_contact_mail HR_EMPLOYEE.contact_mail%type, 
                              piv_contact_number HR_EMPLOYEE.contact_number%type);
    PROCEDURE delete_employee_by_id(pin_employee_id HR_EMPLOYEE.employee_id%type);
    PROCEDURE delete_employee_by_identity_no(pin_identity_no HR_EMPLOYEE.identity_no%type);
    PROCEDURE assign_department_to_employee(pin_employee_id hr_employee.employee_id%type, pin_department_id HR_EMPLOYEE.department_id%type);
    PROCEDURE assign_manager_to_employee(pin_employee_id hr_employee.employee_id%type, pin_manager_id HR_EMPLOYEE.manager_id%type);
    FUNCTION get_employee_by_id(pin_employee_id hr_employee.employee_id%type) RETURN SYS_REFCURSOR;
    FUNCTION get_employee_by_identity_no(pin_identity_no hr_employee.identity_no%type) RETURN SYS_REFCURSOR;
    PROCEDURE update_employee_by_id(pin_employee_id hr_employee.employee_id%type, pin_manager_id hr_employee.manager_id%type, 
                                    pin_department_id HR_EMPLOYEE.department_id%type, piv_position HR_EMPLOYEE.position%type, 
                                    pin_identity_no HR_EMPLOYEE.identity_no%type, piv_name HR_EMPLOYEE.name%type, 
                                    piv_surname HR_EMPLOYEE.surname%type, piv_contact_mail HR_EMPLOYEE.contact_mail%type, 
                                    piv_contact_number HR_EMPLOYEE.contact_number%type, pid_hire_date HR_EMPLOYEE.hire_date%type);
    
    
    --- HR_DEPARTMENT ---
    PROCEDURE insert_department(pin_superior_department_id HR_DEPARTMENT.superior_department_id%type, pin_manager_id HR_DEPARTMENT.manager_id%type, 
                                piv_department_name HR_DEPARTMENT.department_name%type, pin_agency_code HR_DEPARTMENT.agency_code%type, 
                                piv_contact_mail HR_DEPARTMENT.contact_mail%type, piv_contact_number HR_DEPARTMENT.contact_number%type, 
                                pin_contact_employee_id HR_DEPARTMENT.contact_employee_id%type);
    PROCEDURE delete_department_by_id(pin_department_id HR_DEPARTMENT.department_id%type);
    PROCEDURE assign_manager_to_department(pin_department_id hr_department.department_id%type, pin_manager_id hr_department.manager_id%type);
    PROCEDURE assign_employee_to_department(pin_department_id hr_department.department_id%type, pin_contact_employee_id hr_department.contact_employee_id%type);
    FUNCTION get_department_by_id(pin_department_id HR_DEPARTMENT.department_id%type) RETURN SYS_REFCURSOR;
    PROCEDURE update_department_by_id(pin_department_id HR_DEPARTMENT.department_id%type, pin_superior_department_id HR_DEPARTMENT.superior_department_id%type, pin_manager_id HR_DEPARTMENT.manager_id%type, 
                                      piv_department_name HR_DEPARTMENT.department_name%type, pin_agency_code HR_DEPARTMENT.agency_code%type, 
                                      piv_contact_mail HR_DEPARTMENT.contact_mail%type, piv_contact_number HR_DEPARTMENT.contact_number%type, 
                                      pin_contact_employee_id HR_DEPARTMENT.contact_employee_id%type);
    
    --- HR_DOCUMENT_TYPE ---
    PROCEDURE insert_document_type(piv_document_type_name HR_DOCUMENT_TYPE.DOCUMENT_TYPE_NAME%TYPE);
    FUNCTION get_document_type_by_type(pin_document_type HR_DOCUMENT_TYPE.document_type%TYPE) RETURN SYS_REFCURSOR;
    PROCEDURE update_document_type_by_type(pin_document_type HR_DOCUMENT_TYPE.document_type%TYPE, piv_document_type_name HR_DOCUMENT_TYPE.DOCUMENT_TYPE_NAME%TYPE);
    
    --- HR_DOCUMENT ---
    PROCEDURE insert_document(pin_document_type hr_document.document_type%type, piv_document_file_name hr_document.document_file_name%type, 
                              piv_document_name hr_document.document_name%type, pin_related_employee_id hr_document.related_employee_id%type);
    PROCEDURE delete_document_by_id(pin_document_id hr_document.document_id%type);
    PROCEDURE assign_employee_to_document(pin_document_id hr_document.document_id%type, pin_related_employee_id hr_document.related_employee_id%type);
    PROCEDURE assign_type_to_document(pin_document_id hr_document.document_id%type, pin_document_type hr_document.document_type%type);
    FUNCTION get_document_by_id(pin_document_id HR_DOCUMENT.document_id%TYPE) RETURN SYS_REFCURSOR;
    PROCEDURE update_document_by_id(pin_document_id hr_document.document_id%type, pin_document_type hr_document.document_type%type, 
                                    piv_document_file_name hr_document.document_file_name%type, pib_document_content hr_document.document_content%type, 
                                    piv_document_name hr_document.document_name%type, pin_related_employee_id hr_document.related_employee_id%type);
    
    
    --- HR_NOTES ---
    PROCEDURE insert_note(pin_related_employee_id hr_notes.related_employee_id%type, piv_note_content hr_notes.note_content%type);
    PROCEDURE delete_note_by_id(pin_note_id hr_notes.note_id%type);
    PROCEDURE assign_employee_to_note(pin_note_id hr_notes.note_id%type, pin_related_employee_id hr_notes.related_employee_id%type);
    FUNCTION get_note_by_id(pin_note_id HR_NOTES.note_id%TYPE) RETURN SYS_REFCURSOR;
    PROCEDURE update_note_by_id(pin_note_id hr_notes.note_id%type, pin_related_employee_id hr_notes.related_employee_id%type, 
                                piv_note_content hr_notes.note_content%type);
    
    
    --- HR_ANNUAL_LEAVE ---
    PROCEDURE insert_annual_leave(pin_related_employee_id hr_annual_leave.related_employee_id%type, pid_begin_date hr_annual_leave.begin_date%type, 
                                  pid_end_date hr_annual_leave.end_date%type, pin_number_of_business_days hr_annual_leave.number_of_business_days%type);
    PROCEDURE delete_annual_leave_by_id(pin_annual_leave_id hr_annual_leave.annual_leave_id%type);
    PROCEDURE assign_employee_to_annual(pin_annual_leave_id hr_annual_leave.annual_leave_id%type, pin_related_employee_id hr_annual_leave.related_employee_id%type);
    FUNCTION get_annual_leave_by_id(pin_annual_leave_id HR_ANNUAL_LEAVE.annual_leave_id%TYPE) RETURN SYS_REFCURSOR;
    PROCEDURE update_annual_leave_by_id(pin_annual_leave_id hr_annual_leave.annual_leave_id%type, 
                                        pin_related_employee_id hr_annual_leave.related_employee_id%type,
                                        pin_approver_employee_id hr_annual_leave.approver_employee_id%type,
                                        pin_proxy_employee_id hr_annual_leave.proxy_employee_id%type,
                                        pid_begin_date hr_annual_leave.begin_date%type, 
                                        pid_end_date hr_annual_leave.end_date%type, 
                                        pin_number_of_business_days hr_annual_leave.number_of_business_days%type);
END MSU_HR;