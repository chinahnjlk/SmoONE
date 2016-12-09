using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SmoONE.UI
{
    // ******************************************************************
    // �ļ��汾�� SmoONE 1.0
    // Copyright  (c)  2016-2017 Smobiler 
    // ����ʱ�䣺 2016/11
    // ��Ҫ���ݣ�  ע�����
    // ******************************************************************
    partial class frmRegisterTel : Smobiler.Core.MobileForm
    {
        #region "definition"
        AutofacConfig AutofacConfig = new AutofacConfig();//����������
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTel.Text.Trim().Length <= 0)
                {
                    throw new Exception("������绰���룡");

                }
                else
                {
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[1][3-8]\d{9}$");
                    if (regex.IsMatch(txtTel.Text.Trim())==false )
                    {
                        throw new Exception("�ֻ������ʽ����ȷ��");
                    }
                }
                //��֤�绰�����Ƿ��Ѿ�ע�ᣬ������ֵΪtrueʱ����ʾ��ע��
               bool isRegister= AutofacConfig.userService.IsExists(txtTel.Text.Trim());
               if (isRegister == true)
               {
                   throw new Exception("�绰����" + txtTel.Text.Trim()+"��ע�ᣡ");
               }
               else
               {
                   frmVerificationCode frmVerificationCode = new frmVerificationCode();
                   frmVerificationCode.Tel = txtTel.Text.Trim();
                   Redirect(frmVerificationCode);
               }
            }
            catch(Exception ex)
            {
                Toast(ex.Message, ToastLength.SHORT);
            }
        }
        /// <summary>
        /// �ֻ��Դ����˰�ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRegisterTel_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
                Close();         //�رյ�ǰҳ��
            }
        }
        /// <summary>
        /// ������ͼƬ��ť����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRegisterTel_TitleImageClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}