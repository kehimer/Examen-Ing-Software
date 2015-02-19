using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Domino.Spec
{
    [Binding]
    public class DominoTest
    {
        [Given(@"I have the following pieces in the stack")]
        public void GivenIHaveTheFollowingPiecesInTheStack(Table table)
        {
           
        }

        [Given(@"I have the following seed (.*)")]
        public void GivenIHaveTheFollowingSeed(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I desorneno las peizas")]
        public void WhenIDesornenoLasPeizas()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
