using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableBullet<T> where T : MonoBehaviour, IPoolableBullet<T>
{
    public void InitializeBullet(BulletPool<T> pool);

    //public void InitializeWolf(WolfPool<T> pool);

    //public void InitializeBoar(BoarPool<T> pool);
    //public void InitializeGoat(GoatPool<T> pool);
    //public void InitializeGoblin(GoblinPool<T> pool);
    //public void InitializeSheep(SheepPool<T> pool);

    public void Deactivate();

    public void Activate();

}
