-- Insert as Scenes
INSERT INTO TakeAStep01.dbo.Scenes (_Id, storyId, Text, Type)
VALUES 
(
    1, 
    1, 
    'You wake up on a deserted island. You see smoke rising in the distance. What do you do?',
    'initial'
),
(
    2, 
    1, 
    'You head towards the smoke and find a tribe of natives. They welcome you and offer to help you leave the island.',
    NULL
),
(
    3,
    1,
    'You wait for rescue, but after several days, no one comes. You start to run out of food and water. What do you do?',
    NULL
),
(
    4,
    1,
    'The natives help you build a raft and give you directions to the nearest inhabited island. You set out and eventually make it back home.',
    'end'
),
(
    5,
    1,
    'You search for food and water, but end up getting lost in the wilderness. You eventually find your way back to your shelter, but you''''re weak and hungry.',
    NULL
),
(
    6,
    1,
    'You build a shelter and wait for rescue. After several more days, you are finally rescued, but you are weak and dehydrated.',
    'end'
),
(
    7,
    1,
    'You return home and resume your life, grateful for the experience and the lessons you learned.',
    'end'
)

-- Insert das SceneEffects
INSERT INTO TakeAStep01.dbo.SceneEffects(_Id, sceneId, goldChange, hpChange)
VALUES
(
    1, 1, 0, 0
),
(
    2, 2, 0, 0
)