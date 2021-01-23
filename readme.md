Classes: 
1. Models.Jobs - Abstract Class of Jobs (Dependent Job and Independent Job)
2. Models.DependentJobs - Implements Models.Job (a => b)
3. Models.IndependentJobs - Implements Model.Job (a => )
4. JobInputParser - Parse user input line into Job, it handles exceptions:
   - Invalid dependency sign (e.g. a => b => c, a, => b)
   - invalid input format (e.g. a => b c, a b => c)
   - invalid job name (e.g. ab => cd, ab => c, c => ab)
   - Self-dependent (e.g. a => a)
5. JobsRepository 
   - stores all jobs created from JobInputParser
   - it shows dependency, which is protected by validator
      - Firstly find out all end node
      - Then find its parent node recursively
      - the dependency should be the reverse order of node searching (bottom-up approach)
6. JobFactory - to read jobs from Console or from a text file
7. JobsValidator - it handles exceptions:
   - Unspecified Job (a => b, where missing b => )
   - Duplicate job (a => b, a => c. where a is duplicate)
   - Circular dependent (a => b, b => c, c => a)
8. UnitTest_JobInputParser - Unit test class of JobInputParser
   - Test_DependentJob (a => b)
   - Test_IndependentJob (a =>)
   - Test_InvalidDependencySign1 (missing =>)
   - Test_InvalidDependencySign2 (missing job)
   - Test_InvalidFormat (a => b c)
   - Test_InvalidJobName (ab => c)
   - Test_InvalidNextJobName (c => ab)
   - Test_SelfDependent1 (normal flow: a => b)
   - Test_SelfDependent2 (Exceptional flow: a => a)
9. UnitTest_JobsValidator - Unit test class of JobsValidator
   - Test_checkMultipleJobName1 (normal flow)
   - Test_checkMultipleJobName2 (exceptional flow: a => b, a => c)
   - Test_checkUnspecifiedNextJob1 (normal flow)
   - Test_checkUnspecifiedNextJob2 (exceptional flow: a => b, where b is missing b =>)
   - Test_checkCircularDependent1 (normal flow: single tree)
   - Test_checkCircularDependent2 (exceptional flow: single loop)
   - Test_checkCircularDependent3 (normal flow: 2 trees)
   - Test_checkCircularDependent4 (exceptional flow: 1 loop + 1 tree)
   - Test_checkCircularDependent5 (exceptional flow: 1 loop + 1 tree)
10. UnitTest_JobRepository  - Unit test class of JobsRepository
   - Test_showDependencies1 (single tree: a => b, b => c, c => )
   - Test_showDependencies2 (2 trees)
   - Test_showDependencies2 (2 trees)
11. UnitTest_JobFactory  - Unit test class of JobFactory
   - Test_readJobsFromConsole 
   - Test_readJobsFromFile
