using System;

namespace ZenjectDemo.Modules.GameplayModule
{
    public interface IPlayerFacade
    {
        Action DieAction { get; set; }
    }
}
