using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using StateMachineCapstone;
using StateMachineCapstone.Contexts;
using StateMachineCapstone.States;
using Xunit;

namespace SubjectStateTests
{
    public class SubjectStateMachineTests
    {
        private static CourseAdminContext _adminContext;
        private static TeacherContext _teacherContext;

        public SubjectStateMachineTests()
        {
            _adminContext = new CourseAdminContext(new New());
            _teacherContext = new TeacherContext(new InProgress());
        }

        private static CourseAdminContext InitializeCourseAdminContext(CourseAdminContext context)
        {
            _adminContext = context;
            return _adminContext;
        }

        private static TeacherContext InitializeTeacherContext(TeacherContext context)
        {
            _teacherContext = context;
            return _teacherContext;
        }

        [Fact]
        public void CreateNewSubject_Transitions_New()
        {
            var state = _adminContext.SubjectState;
            Assert.IsType<New>(state);
        }

        [Fact]
        public void Teacher_InProgress_Submit_TransitionsToSubmitted()
        {
            InitializeTeacherContext(new TeacherContext(new InProgress()));
            _teacherContext.Submit();
            var state = _teacherContext.SubjectState;
            Assert.IsType<Submitted>(state);
        }

        [Fact]
        public void Teacher_Submitted_Grab_TransitionsToInProgress()
        {
            InitializeTeacherContext(new TeacherContext(new Submitted()));
            _teacherContext.Grab();
            var state = _teacherContext.SubjectState;
            Assert.IsType<InProgress>(state);
        }

        [Fact]
        public void Teacher_Submitted_Submit_ThrowsException()
        {
            InitializeTeacherContext(new TeacherContext(new Submitted()));
            Assert.Throws<InvalidOperationException>(() => _teacherContext.Submit());
        }

        [Fact]
        public void Teacher_InProgress_Grab_ThrowsException()
        {
            InitializeTeacherContext(new TeacherContext(new InProgress()));
            Assert.Throws<InvalidOperationException>(() => _teacherContext.Grab());
        }

        [Theory]
        [MemberData(nameof(ValidTransitionTestData))]
        public void CourseAdminGivenValidState_Action_TransitionsToCorrectState(CourseAdminContext contextInstance, Action contextAction, SubjectState expectedState)
        {
            contextAction.Invoke();
            var state = contextInstance.SubjectState;
            var theType = expectedState.GetType();
            Assert.IsType(theType, state);
        }

        [Theory]
        [MemberData(nameof(InValidTransitionTestData))]
        public void CourseAdminGivenInvalidState_Action_ThrowsException(CourseAdminContext contextInstance, Action contextAction)
        {
            Assert.Throws<InvalidOperationException>(() => contextAction?.Invoke());
        }

        public static IEnumerable<object[]> InValidTransitionTestData()
        {
            //New
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new New())), new Action(_adminContext.Approve) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new New())), new Action(_adminContext.Submit) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new New())), new Action(_adminContext.Restore) };

            //In Progress
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new InProgress())), new Action(_adminContext.Restore) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new InProgress())), new Action(_adminContext.Approve) };

            //Submitted
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Submitted())), new Action(_adminContext.Restore) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Submitted())), new Action(_adminContext.Submit) };

            //Approved
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Approved())), new Action(_adminContext.Restore) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Approved())), new Action(_adminContext.Approve) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Approved())), new Action(_adminContext.Submit) };

            //Deleted
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Deleted())), new Action(_adminContext.Assign) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Deleted())), new Action(_adminContext.Approve) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Deleted())), new Action(_adminContext.Delete) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Deleted())), new Action(_adminContext.Submit) };

            //Restored
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Restored())), new Action(_adminContext.Approve) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Restored())), new Action(_adminContext.Submit) };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Restored())), new Action(_adminContext.Restore) };

        }

        public static IEnumerable<object[]> ValidTransitionTestData()
        {
            //New
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new New())), new Action(_adminContext.Assign), new InProgress() };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new New())), new Action(_adminContext.Delete), new Deleted() };

            //In Progress
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new InProgress())), new Action(_adminContext.Submit), new Submitted() };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new InProgress())), new Action(_adminContext.Delete), new Deleted() };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new InProgress())), new Action(_adminContext.Assign), new InProgress() };

            //Submitted
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Submitted())), new Action(_adminContext.Approve), new Approved() };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Submitted())), new Action(_adminContext.Delete), new Deleted() };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Submitted())), new Action(_adminContext.Assign), new InProgress() };

            //Approved
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Approved())), new Action(_adminContext.Delete), new Deleted() };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Approved())), new Action(_adminContext.Assign), new InProgress() };

            //Deleted
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Deleted())), new Action(_adminContext.Restore), new Restored() };

            //Restored
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Restored())), new Action(_adminContext.Assign), new InProgress() };
            yield return new object[] { InitializeCourseAdminContext(new CourseAdminContext(new Restored())), new Action(_adminContext.Delete), new Deleted() };
        }
    }
}
