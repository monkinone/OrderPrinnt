using System;

namespace Beyondbit.OA.Common
{

    /// <summary>
    /// TaskCenter任务状态位
    /// </summary>
    public enum TaskStatus
    {
        All = -1,				//所有
        UnDo = 0,				//未执行
        Done = 2,				//完成
        Suspend = 3,		    //挂起
        Frozen = 4,		        //冻结
        Dismiss = 5,			//撤消
        Cancel = 10			    //取消
    }

    /// <summary>
    /// project状态位
    /// </summary>
    public enum ProjectStatus
    {
        All = -1,				//所有
        Undo = 0,				//未流转
        Doing = 1,				//流转
        Done = 2,				//流转结束
        Hang = 5,				//留存
        ReadyAchieve = 6,	    //拟归档
        Achieved = 7,			//已归档
        Cancel = 10				//已撤消
    }

    /// <summary>
    /// 列表类型的枚举
    /// </summary>
    public enum ListType
    {
        ToDo,					//待办
        Done,					//已办
        ToRead,				    //待阅
        ToReadAll,			    //待阅包含已阅
        HangUp,	                //挂起
        Trash,					//回收
        All,						//所有
        Unit,                   //本单位所有
        AllUnit,                 //所有单位
        ToRec                   //签收
    }
}
