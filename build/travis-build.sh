#!/usr/bin/env bash
set -e

BUILD_VERSION="0.9.$TRAVIS_BUILD_NUMBER"

# Install SonarScanner
dotnet tool install --global dotnet-sonarscanner
export PATH="~/.dotnet/tools:$PATH"

cd src

# Start the SonarScanner
if [ "$TRAVIS_PULL_REQUEST" == "false" ]
then
    echo "Standard branch build"

    dotnet sonarscanner begin \
        /k:"lholota_dhcp-dotnet" \
        /o:lholota \
        /d:"sonar.host.url=https://sonarcloud.io" \
        /d:"sonar.login=$SONARCLOUD_TOKEN" \
        /d:"sonar.cs.vstest.reportsPaths=$TRAVIS_BUILD_DIR/src/**/TestResults/*.trx" \
        /d:"sonar.cs.opencover.reportsPaths=$TRAVIS_BUILD_DIR/src/**/coverage.opencover.xml" \
        /d:"sonar.scm.revision=$TRAVIS_COMMIT" \
        /d:"sonar.links.scm=https://github.com/lholota/dhcp-dotnet" \
        /d:"sonar.branch.name=$TRAVIS_BRANCH"
else
    echo "Pull request build"
    
    dotnet sonarscanner begin \
        /k:"lholota_dhcp-dotnet" \
        /o:lholota \
        /d:"sonar.host.url=https://sonarcloud.io" \
        /d:"sonar.login=$SONARCLOUD_TOKEN" \
        /d:"sonar.cs.vstest.reportsPaths=$TRAVIS_BUILD_DIR/src/**/TestResults/*.trx" \
        /d:"sonar.cs.opencover.reportsPaths=$TRAVIS_BUILD_DIR/src/**/coverage.opencover.xml" \
        /d:"sonar.scm.revision=$TRAVIS_COMMIT" \
        /d:"sonar.links.scm=https://github.com/lholota/dhcp-dotnet" \
        /d:"sonar.pullrequest.key=$TRAVIS_PULL_REQUEST" \
        /d:"sonar.pullrequest.branch=$TRAVIS_PULL_REQUEST_BRANCH" \
        /d:"sonar.pullrequest.base=$TRAVIS_BRANCH" \
        /d:"sonar.pullrequest.github.repository=$TRAVIS_PULL_REQUEST_SLUG" \
        /d:"sonar.pullrequest.provider=GitHub"
fi

dotnet build -c Release -p:Version=$BUILD_VERSION

dotnet test -c Release --no-build --no-restore \
        -p:Version=$BUILD_VERSION \
        --logger "trx" \
        /p:CollectCoverage=true \
        /p:CoverletOutputFormat=opencover

dotnet sonarscanner end /d:sonar.login=$SONARCLOUD_TOKEN