using System;
using Microsoft.SPOT;

namespace CTRE.Phoenix.Motion
{
    /**
     * Motion Profile Status
     * This is simply a data transer object.
     */
    public struct MotionProfileStatus
    {
        /**
         * The available empty slots in the trajectory buffer.
         *
         * The robot API holds a "top buffer" of trajectory points, so your applicaion
         * can dump several points at once.  The API will then stream them into the Talon's
         * low-level buffer, allowing the Talon to act on them.
         */
        public UInt32 topBufferRem;
        /**
         * The number of points in the top trajectory buffer.
         */
        public UInt32 topBufferCnt;
        /**
         * The number of points in the low level Talon buffer.
         */
        public UInt32 btmBufferCnt;
        /**
         * Set if isUnderrun ever gets set.
         * Only is cleared by clearMotionProfileHasUnderrun() to ensure
         * robot logic can react or instrument it.
         * @see clearMotionProfileHasUnderrun()
         */
        public bool hasUnderrun;
        /**
         * This is set if Talon needs to shift a point from its buffer into
         * the active trajectory point however the buffer is empty. This gets cleared
         * automatically when is resolved.
         */
        public bool isUnderrun;
        /**
         * True if the active trajectory point has not empty, false otherwise.
         * The members in activePoint are only valid if this signal is set.
         */
        public bool activePointValid;
        /**
         * The number of points in the low level Talon buffer.
         */
        public TrajectoryPoint activePoint;
        /**
         * The current output mode of the motion profile executer (disabled, enabled, or hold).
         * When changing the set() value in MP mode, it's important to check this signal to
         * confirm the change takes effect before interacting with the top buffer.
         */
        public SetValueMotionProfile outputEnable;
    };
}