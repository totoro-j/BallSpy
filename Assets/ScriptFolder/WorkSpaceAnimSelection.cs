using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class WorkSpaceAnimSelection : MonoBehaviour {
	public Sequence ComponentAnim;
	public int AnimType;
	private Vector3 v1;
	private Vector3 v2;

	void Awake(){
		//工作台动画列表
		switch (AnimType) {
		case 0:
			v1 = new Vector3 (0,0,180);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation", v1)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation", v1)));
			break;
		case 1:
			v1 = new Vector3 (-0.78f, 0, 0);
			ComponentAnim = new Sequence (new SequenceParms ().Loops (-1, LoopType.Restart));
			ComponentAnim.Prepend (HOTween.To (transform, 1.5f, new TweenParms ().Prop ("position",transform.position + v1).Ease (EaseType.Linear)));
			ComponentAnim.Append (HOTween.To (transform, 1.5f, new TweenParms ().Prop ("position", transform.position).Ease (EaseType.Linear)));
			break;
		case 2:
			v1 = new Vector3 (0,0,180);
			v2 = new Vector3 (0,0,180);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation", v1)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation", v2)));
			break;
		case 3:
			v1=new Vector3(0.23f,0,0);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 0.5f, new TweenParms().Prop("position", transform.position+v1).Ease(EaseType.Linear)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("position", transform.position).Ease(EaseType.Linear)));
			break;
		case 4:
			v1 = new Vector3 (-0.23f, 0, 0);
			ComponentAnim = new Sequence (new SequenceParms ().Loops (-1, LoopType.Restart));
			ComponentAnim.Prepend (HOTween.To (transform, 0.5f, new TweenParms ().Prop ("position", transform.position + v1).Ease (EaseType.Linear)));
			ComponentAnim.Append (HOTween.To (transform, 0.5f, new TweenParms ().Prop ("position", transform.position).Ease (EaseType.Linear)));
			break;
		case 5:
			v1 = new Vector3 (0,0,180);
			v2 = new Vector3 (0,0,180);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation", v1)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation", v2)));
			break;
		case 6:
			v1 = new Vector3 (0,0,-45);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation",-v1).Ease(EaseType.EaseInBack)));
			ComponentAnim.Append(HOTween.To(transform, 2f, new TweenParms().Prop("position",transform.position)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation",new Vector3(0,0,0)).Ease(EaseType.EaseInBack)));
			break;
		case 7:
			v1 = new Vector3 (0,0,-45);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 0.5f, new TweenParms().Prop("position",transform.position)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation",-v1).Ease(EaseType.EaseInBack)));
			ComponentAnim.Append(HOTween.To(transform, 1f, new TweenParms().Prop("position",transform.position)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation",new Vector3(0,0,0)).Ease(EaseType.EaseInBack)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("position",transform.position)));
			break;
		case 8:
			v1 = new Vector3 (0,0,-45);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 1f, new TweenParms().Prop("position",transform.position)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation",-v1).Ease(EaseType.EaseInBack)));
			ComponentAnim.Append(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation",new Vector3(0,0,0)).Ease(EaseType.EaseInBack)));
			ComponentAnim.Append(HOTween.To(transform, 1f, new TweenParms().Prop("position",transform.position)));
			break;
		case 9:
			v1 = new Vector3(0,0.44f,0);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 1.5f, new TweenParms().Prop("position", transform.position+v1).Ease(EaseType.EaseInCirc)));
			ComponentAnim.Append(HOTween.To(transform, 1f, new TweenParms().Prop("position", transform.position).Ease(EaseType.Linear)));
			break;
		case 10:
			v1 = new Vector3 (0, 1.56f, 0);
			ComponentAnim = new Sequence (new SequenceParms ().Loops (-1, LoopType.Restart));
			ComponentAnim.Prepend (HOTween.	To (transform, 1.5f, new TweenParms ().Prop ("position", transform.position + v1).Ease (EaseType.EaseInCirc)));
			ComponentAnim.Append (HOTween.To (transform, 1f, new TweenParms ().Prop ("position", transform.position).Ease (EaseType.Linear)));
			break;
		case 12:
			v1 = new Vector3 (0,0,-60);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Yoyo));
			ComponentAnim.Prepend(HOTween.To(transform, 0.5f, new TweenParms().Prop("rotation",v1).Ease(EaseType.Linear)));
			break;
		case 13:
			v1 = new Vector3 (0,0,0.0156f);
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 0.2f, new TweenParms().Prop("position",transform.position+v1)));
			break;
		case 14:
			ComponentAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
			ComponentAnim.Prepend(HOTween.To(transform, 1.25f, new TweenParms().Prop("rotation",new Vector3(0,0,15))));		
			ComponentAnim.Append(HOTween.To(transform, 1.25f, new TweenParms().Prop("rotation",new Vector3(0,0,0)).Delay(0.5f)));
			break;
		}
	}
}
