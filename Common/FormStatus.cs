using System;

namespace Beyondbit.OA.Common
{

    /// <summary>
    /// TaskCenter����״̬λ
    /// </summary>
    public enum TaskStatus
    {
        All = -1,				//����
        UnDo = 0,				//δִ��
        Done = 2,				//���
        Suspend = 3,		    //����
        Frozen = 4,		        //����
        Dismiss = 5,			//����
        Cancel = 10			    //ȡ��
    }

    /// <summary>
    /// project״̬λ
    /// </summary>
    public enum ProjectStatus
    {
        All = -1,				//����
        Undo = 0,				//δ��ת
        Doing = 1,				//��ת
        Done = 2,				//��ת����
        Hang = 5,				//����
        ReadyAchieve = 6,	    //��鵵
        Achieved = 7,			//�ѹ鵵
        Cancel = 10				//�ѳ���
    }

    /// <summary>
    /// �б����͵�ö��
    /// </summary>
    public enum ListType
    {
        ToDo,					//����
        Done,					//�Ѱ�
        ToRead,				    //����
        ToReadAll,			    //���İ�������
        HangUp,	                //����
        Trash,					//����
        All,						//����
        Unit,                   //����λ����
        AllUnit,                 //���е�λ
        ToRec                   //ǩ��
    }
}
