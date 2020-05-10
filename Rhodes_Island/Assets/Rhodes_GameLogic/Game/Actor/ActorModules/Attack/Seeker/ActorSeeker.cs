using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ActorSeeker{
	/*返回监控区域内攻击优先级最高的对象，区域内无可用对象时返回null*/
	GameObject getFocus();

	/*返回 count 个攻击区域内的对象，优先级从高到低排列*/
	GameObject[] getFocusList(int count);

	/*返回监控区域内的所有对象*/
	GameObject[] getCaptureList();

	/*范围内存在目标*/
	bool targetExist();

}