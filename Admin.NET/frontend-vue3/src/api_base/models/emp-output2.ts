/* tslint:disable */
/* eslint-disable */
/**
 * Admin.NET通用权限管理平台
 * 前后端分离架构，开箱即用，紧随前沿技术。<br/><a href='https://gitee.com/zuohuaijun/Admin.NET/'>https://gitee.com/zuohuaijun/Admin.NET</a>
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
/**
 * 员工信息参数2
 * @export
 * @interface EmpOutput2
 */
export interface EmpOutput2 {
    /**
     * 员工Id
     * @type {string}
     * @memberof EmpOutput2
     */
    id?: any | null;
    /**
     * 工号
     * @type {string}
     * @memberof EmpOutput2
     */
    jobNum?: any | null;
    /**
     * 机构Id
     * @type {string}
     * @memberof EmpOutput2
     */
    orgId?: any | null;
    /**
     * 机构名称
     * @type {string}
     * @memberof EmpOutput2
     */
    orgName?: any | null;
    /**
     * 附属机构
     * @type {Array&lt;EmpExtOrgPosOutput&gt;}
     * @memberof EmpOutput2
     */
    extIds?: any | null;
    /**
     * 职位集合
     * @type {Array&lt;number&gt;}
     * @memberof EmpOutput2
     */
    posIdList?: any | null;
}